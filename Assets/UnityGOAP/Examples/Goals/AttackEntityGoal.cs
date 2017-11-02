using System.Collections.Generic;
using UnityGOAP.Examples.Util;

namespace UnityGOAP.Examples.Goals {
    public class AttackEntityGoal : Goal {
        public NearEntityPreconditionWrapper NearPrecondition;

        public override IEnumerable<Precondition> GetCompletionPreconditions() {
            yield return NearPrecondition.Precondition;
        }
    }
}