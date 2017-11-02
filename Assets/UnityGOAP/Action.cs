using UnityEngine;

namespace UnityGOAP {
    public abstract class Action : MonoBehaviour {
        
    }

    public abstract class Precondition {
        public abstract bool IsMet();
    }
}