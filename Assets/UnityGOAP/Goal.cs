using System.Collections.Generic;
using System.Linq;

namespace UnityGOAP {
    public abstract class Goal {
        public abstract IEnumerable<Precondition> GetCompletionPreconditions();

        public virtual bool IsMet() {
            return GetCompletionPreconditions().All(precondition => precondition.IsMet());
        }
    }

    public abstract class InfiniteGoal : Goal {
        public sealed override bool IsMet() {
            // I N F I N I T E   G O A L
            return false;
        }
    }
}