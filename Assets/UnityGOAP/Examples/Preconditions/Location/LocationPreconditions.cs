using UnityEngine;
using UnityGOAP.Examples.Preconditions.Entity;
using UnityGOAP.State;

namespace UnityGOAP.Examples.Preconditions.Location {
    public abstract class LocationPrecondition : Precondition {
        protected abstract Vector3 GetTargetPosition();
        protected LocationPrecondition() { }

        public override void SetVariables(EntityState state) {
            state.SetValue(StateVariables.TargetLocation, GetTargetPosition());
        }
    }


    public abstract class NearLocationPrecondition : LocationPrecondition {
        /// <summary>
        /// The minimum required distance the Entity needs to be to the target position
        /// </summary>
        public float DistanceThreshold;

        protected NearLocationPrecondition() { }

        protected NearLocationPrecondition(float distanceThreshold) {
            DistanceThreshold = distanceThreshold;
        }

        public override bool IsMet(GOAPAgent agent) {
            var e = agent.EntityStateProvider as Examples.Entity;
            if (!e) {
                return false;
            }
            return Vector3.Distance(GetTargetPosition(), e.Position) <= DistanceThreshold;
        }
    }

    public class NearFixedLocationPrecondition : NearLocationPrecondition {
        public Vector3 Pos;
        public NearFixedLocationPrecondition() { }

        public NearFixedLocationPrecondition(float distanceThreshold, Vector3 pos) : base(distanceThreshold) {
            Pos = pos;
        }

        protected override Vector3 GetTargetPosition() {
            return Pos;
        }
    }
}