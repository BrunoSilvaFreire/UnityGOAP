using UnityGOAP.State;

namespace UnityGOAP {
    public abstract class Precondition {
        public virtual void SetVariables(EntityState state) { }
        public abstract bool IsMet(GOAPAgent agent);
    }
}