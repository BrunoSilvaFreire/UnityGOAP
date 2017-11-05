using System.Collections.Generic;
using System.Linq;

namespace UnityGOAP {
    public abstract class Goal {
        public abstract IEnumerable<Precondition> GetCompletionPreconditions(GOAPAgent agent);

        public virtual bool IsMet(GOAPAgent agent) {
            return GetCompletionPreconditions(agent).All(precondition => precondition.IsMet(agent));
        }

        public virtual void OnInit(GOAPAgent agent) { }
        public virtual void OnUpdate(GOAPAgent agent) { }
        public virtual void OnTerminate(GOAPAgent agent) { }
    }

    public abstract class InfiniteGoal : Goal {
        public sealed override bool IsMet(GOAPAgent agent) {
            // I N F I N I T E   G O A L
            return false;
        }

    }
}