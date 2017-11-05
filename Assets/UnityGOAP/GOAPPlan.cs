using System.Collections.Generic;
using System.Linq;

namespace UnityGOAP {
    public sealed class GOAPPlan {
        private Queue<GOAPPlanNode> actionQueue;

        public override string ToString() {
            var s = string.Join(", ", actionQueue.ToList().Select(node => node.ToString()).ToArray());
            return string.Format("Plan(ActionQueue: {0}, CurrentNode: {1})", s, CurrentNode);
        }

        public GOAPPlan(Queue<GOAPPlanNode> actionQueue) {
            this.actionQueue = actionQueue;
        }

        public void Init(GOAPAgent agent) {
            Continue(agent);
        }

        public GOAPPlanNode CurrentNode {
            get;
            private set;
        }

        public void Continue(GOAPAgent agent) {
            if (actionQueue.Count <= 0) {
                return;
            }
            if (CurrentNode != null) {
                CurrentNode.OnTerminate(agent);
            }
            CurrentNode = actionQueue.Dequeue();
            CurrentNode.Precondition.SetVariables(agent.EntityState);
            CurrentNode.OnInit(agent);
        }

        public void ForceEnqueue(GOAPAgent agent, Precondition precondition) {
            var action = agent.GetBestActionFor(precondition);
            actionQueue.Enqueue(new GOAPPlanNode(action, precondition));
        }
    }

    public sealed class GOAPPlanNode {
        /// <summary>
        /// The action that will solve the <see cref="Precondition"/>
        /// </summary>
        public Action Action;

        /// <summary>
        /// The precondition the <see cref="Action"/> is responsible for meeting.
        /// </summary>
        public Precondition Precondition;

        public ListenerInfo ActionInfo;
        public ListenerInfo PreconditionInfo;
        public GOAPPlanNode() { }

        public GOAPPlanNode(Action action, Precondition precondition) {
            Action = action;
            Precondition = precondition;
            ActionInfo = new ListenerInfo(action);
        }


        public void OnInit(GOAPAgent agent) {
            if (PreconditionInfo.Init) {
                ((IGOAPInitListener) Precondition).OnInit(agent);
            }
            if (ActionInfo.Init) {
                ((IGOAPInitListener) Action).OnInit(agent);
            }
        }

        public void OnUpdate(GOAPAgent agent) {
            if (PreconditionInfo.Update) {
                ((IGOAPUpdateListener) Precondition).OnUpdate(agent);
            }
            if (ActionInfo.Update) {
                ((IGOAPUpdateListener) Action).OnUpdate(agent);
            }
        }

        public void OnTerminate(GOAPAgent agent) {
            if (PreconditionInfo.Terminate) {
                ((IGOAPTerminateListener) Precondition).OnTerminate(agent);
            }
            if (ActionInfo.Terminate) {
                ((IGOAPTerminateListener) Action).OnTerminate(agent);
            }
        }

        public override string ToString() {
            return string.Format("Node(Action: {0}, Precondition: {1}, Info: {2})", Action, Precondition, ActionInfo);
        }
    }

    public struct ListenerInfo {
        public ListenerInfo(object obj) : this() {
            Update = obj is IGOAPUpdateListener;
            Init = obj is IGOAPInitListener;
            Terminate = obj is IGOAPTerminateListener;
        }

        public bool Update;
        public bool Init;
        public bool Terminate;
    }
}