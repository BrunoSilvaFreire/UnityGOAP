using UnityGOAP;

namespace UnityGOAP {
    public abstract class Precondition {
        public virtual void OnActionStated(GOAPAgent agent) { }
        public abstract bool IsMet();
    }
}