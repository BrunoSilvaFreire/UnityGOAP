using UnityEngine;

namespace UnityGOAP.Examples.Preconditions.Location {
    public class BoundsLocationPrecondition : LocationPrecondition {
        public Bounds Bounds;

        public BoundsLocationPrecondition(Bounds bounds) {
            Bounds = bounds;
        }

        public override Vector3 GetTargetPosition() {
            return Bounds.center;
        }

        public override bool IsMet() {
            return Bounds.Contains(Entity.Position);
        }
    }
}