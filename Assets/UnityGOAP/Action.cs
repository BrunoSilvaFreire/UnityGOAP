using System.Collections.Generic;
using UnityEngine;
using UnityGOAP.State;

namespace UnityGOAP {
    public abstract class Action : MonoBehaviour {
        public abstract float CalculateCost(GOAPAgent agent);
        public abstract float CalculateMotivation(GOAPAgent agent);
        public abstract bool IsPossible(GOAPAgent agent, EntityState state);

        public abstract IEnumerable<Precondition> GetPreconditions();

        public abstract bool SatisfiesPrecondition(Precondition precondition);
    }
}