using UnityEngine;
using UnityGOAP.Examples.Preconditions.Entity;

namespace UnityGOAP.Examples.Preconditions.Location {
    public abstract class LocationPrecondition : EntityPrecondition {
        public abstract Vector3 GetTargetPosition();

        public override void OnActionStated(GOAPAgent agent) {
            agent.EntityStateProvider.EntityState.SetValue(StateVariables.TargetLocation, GetTargetPosition());
        }
    }


    public abstract class NearLocationPrecondition : LocationPrecondition {
        /// <summary>
        /// The minimum required distance the Entity needs to be to the target position
        /// </summary>
        public float DistanceThreshold;

        protected NearLocationPrecondition(float distanceThreshold) {
            DistanceThreshold = distanceThreshold;
        }

        public override bool IsMet() {
            return Vector3.Distance(GetTargetPosition(), Entity.Position) <= DistanceThreshold;
        }
    }
}