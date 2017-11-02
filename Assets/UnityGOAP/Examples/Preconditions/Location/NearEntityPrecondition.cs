using UnityEngine;

namespace UnityGOAP.Examples.Preconditions.Location {
    public class NearEntityPrecondition : NearLocationPrecondition {
        public readonly Examples.Entity Target;

        public NearEntityPrecondition(Examples.Entity target, float distanceThreshold) : base(distanceThreshold) {
            Target = target;
        }

        public override Vector3 GetTargetPosition() {
            return Target.Position;
        }
    }
}