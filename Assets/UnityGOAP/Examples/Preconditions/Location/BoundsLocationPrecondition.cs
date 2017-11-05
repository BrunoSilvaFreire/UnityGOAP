using UnityEngine;

namespace UnityGOAP.Examples.Preconditions.Location {
    public class BoundsLocationPrecondition : LocationPrecondition {
        public Bounds Bounds;

        public BoundsLocationPrecondition(Bounds bounds) {
            Bounds = bounds;
        }

        protected override Vector3 GetTargetPosition() {
            return Bounds.center;
        }

        public override bool IsMet(GOAPAgent agent) {
            return Bounds.Contains(agent.GetProviderAs<Examples.Entity>().Position);
        }
    }
}