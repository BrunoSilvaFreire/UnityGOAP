using System.Collections.Generic;
using UnityEngine;
using UnityGOAP.Examples.Actions.Entity;
using UnityGOAP.Examples.Preconditions.Location;

namespace UnityGOAP.Examples.Actions {
    public class FlyToAction : EntityAction<AirEntity> {
        public override IEnumerable<Precondition> GetPreconditions() {
            yield break;
        }

        public override bool SatisfiesPrecondition(Precondition precondition) {
            return precondition is LocationPrecondition;
        }

        protected override float CalculateCost(GOAPAgent agent, AirEntity entity) {
            var targetPos = entity.EntityState.GetValue(StateVariables.TargetLocation);
            return Vector3.Distance(targetPos, entity.Position);
        }
    }
}