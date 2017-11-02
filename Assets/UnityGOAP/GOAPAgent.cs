using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityGOAP.State;

namespace UnityGOAP {
    public class GOAPAgent : MonoBehaviour {
        private List<Action> knownActions;
        public GameObject ActionsContainer;
        public EntityStateProvider EntityStateProvider;
        private void Awake() {
            knownActions = ActionsContainer.GetComponentsInChildren<Action>().ToList();
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