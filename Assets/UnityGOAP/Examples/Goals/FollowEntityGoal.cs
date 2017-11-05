using System.Collections.Generic;
using UnityGOAP.Examples.Util;

namespace UnityGOAP.Examples.Goals {
    public class FollowEntityGoal : InfiniteGoal {
        public NearEntityPreconditionWrapper NearPrecondition;

        public FollowEntityGoal(Entity entity, float distanceThreshold) {
            NearPrecondition = new NearEntityPreconditionWrapper(entity, distanceThreshold);
        }

        public override IEnumerable<Precondition> GetCompletionPreconditions(GOAPAgent agent) {
            yield return NearPrecondition.Precondition;
        }

        public override void OnUpdate(GOAPAgent agent) {
            var p = NearPrecondition.Precondition;
            if (!p.IsMet(agent)) {
                agent.CurrentPlan.ForceEnqueue(agent, p);
            }
        }
    }
}