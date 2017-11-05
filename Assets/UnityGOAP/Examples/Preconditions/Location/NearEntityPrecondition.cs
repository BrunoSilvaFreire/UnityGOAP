using UnityEngine;
using UnityGOAP.Examples.Util;

namespace UnityGOAP.Examples.Preconditions.Location {
    public class NearEntityPrecondition : NearLocationPrecondition, IEntityContainer<Examples.Entity> {
        public readonly Examples.Entity Target;

        public NearEntityPrecondition(Examples.Entity target, float distanceThreshold) : base(distanceThreshold) {
            Target = target;
        }

        protected override Vector3 GetTargetPosition() {
            return Target.Position;
        }

        public Examples.Entity Entity {
            get {
                return Target;
            }
            set {
                value = Target;
            }
        }
    }
}