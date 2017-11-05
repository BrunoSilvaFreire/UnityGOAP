using System.Collections.Generic;
using UnityGOAP.Examples.Preconditions.Location;
using UnityGOAP.Examples.Util;

namespace UnityGOAP.Examples.Goals {
    public class AttackEntityGoal : Goal {
        public float MinDistance;
        public Entity Entity;
        public override IEnumerable<Precondition> GetCompletionPreconditions(GOAPAgent agent) {
            yield return new NearEntityPrecondition(Entity, MinDistance);
        }
    }
}