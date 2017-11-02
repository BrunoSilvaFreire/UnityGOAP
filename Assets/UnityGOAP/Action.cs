using System.Collections.Generic;
using UnityEngine;

namespace UnityGOAP {
    public abstract class Action : MonoBehaviour {
        public virtual void OnInit(GOAPAgent agent) { }
        public virtual void OnUpdate(GOAPAgent agent) { }
        public virtual void OnTerminate(GOAPAgent agent) { }
        public abstract float CalculateCost(GOAPAgent agent);
        public abstract bool IsPossible(GOAPAgent agent);
        public abstract IEnumerable<Precondition> GetPreconditions();

        public abstract bool SatisfiesPrecondition(Precondition precondition);
    }
}