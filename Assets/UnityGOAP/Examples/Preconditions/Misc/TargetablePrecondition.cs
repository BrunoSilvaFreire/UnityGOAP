using UnityGOAP.Examples.Preconditions.Entity;

namespace UnityGOAP.Examples.Preconditions.Misc {
    public abstract class TargetablePrecondition<T> : EntityPrecondition {
        public T Target;
    }
}