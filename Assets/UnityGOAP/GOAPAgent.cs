using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityGOAP.Exceptions;
using UnityGOAP.State;
using UnityGOAP.Util;

namespace UnityGOAP {
    public class GOAPAgent : MonoBehaviour {
        private List<Action> knownActions;
        public GameObject ActionsContainer;
        public EntityStateProvider EntityStateProvider;
        private Goal currentGoal;

        public T GetProviderAs<T>() where T : class {
            var v = EntityStateProvider as T;
            if (v == null) {
                throw new WTFException();
            }
            return v;
        }

        public EntityState EntityState {
            get {
                return EntityStateProvider.EntityState;
            }
        }

        public GOAPPlan CurrentPlan {
            get;
            private set;
        }

        public Goal CurrentGoal {
            get {
                return currentGoal;
            }
            set {
                currentGoal = value;
                CurrentPlan = CalculatePlan(value);
                CurrentPlan.Init(this);
            }
        }

        private GOAPPlan CalculatePlan(Goal goal) {
            var actions = new Queue<GOAPPlanNode>();
            var preconditionsToMeet = new List<Precondition>(goal.GetCompletionPreconditions(this));
            while (!preconditionsToMeet.IsEmpty()) {
                var precondition = preconditionsToMeet.First();
                var chosenAction = GetBestActionFor(precondition);
                if (chosenAction == null) {
                    //Found no action
                    return null;
                }
                actions.Enqueue(new GOAPPlanNode(chosenAction, precondition));
                preconditionsToMeet.Remove(precondition);
                preconditionsToMeet.AddRange(chosenAction.GetPreconditions());
            }
            return new GOAPPlan(actions);
        }

        internal Action GetBestActionFor(Precondition precondition) {
            var possibleActions = new Dictionary<Action, float>();
            var state = EntityStateProvider.EntityState.Clone();
            precondition.SetVariables(state);
            Debug.Log("Finding best action for " + precondition);
            foreach (var knownAction in KnownActions) {
                if (knownAction.SatisfiesPrecondition(precondition) && knownAction.IsPossible(this, state)) {
                    var cost = CalculateCost(knownAction);
                    possibleActions[knownAction] = cost;
                    Debug.Log("Cost for action " + knownAction + " = " + cost);
                }
            }
            return possibleActions.MinBy(pair => pair.Value).Key;
        }

        private float CalculateCost(Action knownAction) {
            float cost = 0;
            cost += knownAction.CalculateCost(this);
            foreach (var precondition in knownAction.GetPreconditions()) {
                var action = GetBestActionFor(precondition);
                cost += CalculateCost(action);
            }
            var motivation = knownAction.CalculateMotivation(this);
            if (motivation > 0) {
                Debug.Log("Cost to " + knownAction + " was " + cost + ", adding motivation " + motivation);
                cost /= motivation;
            }
            return cost;
        }

        private void Awake() {
            knownActions = ActionsContainer.GetComponentsInChildren<Action>().ToList();
        }

        private void Update() {
            if (currentGoal == null) {
                return;
            }
            var node = CurrentPlan.CurrentNode;
            node.OnUpdate(this);
            var p = node.Precondition;
            if (p.IsMet(this)) {
                CurrentPlan.Continue(this);
            }
            if (currentGoal.IsMet(this)) {
                ResetGoal();
            }
        }

        public void ResetGoal() {
            currentGoal = null;
            CurrentPlan = null;
        }

        public IEnumerable<Action> KnownActions {
            get {
                return knownActions;
            }
        }

        public void AddAction<A>() where A : Action {
            var action = ActionsContainer.AddComponent<A>();
            knownActions.Add(action);
        }
    }
}