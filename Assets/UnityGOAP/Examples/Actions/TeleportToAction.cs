using System.Collections.Generic;
using UnityEngine;
using UnityGOAP.Examples.Actions.Entity;
using UnityGOAP.Examples.Preconditions.Location;
using UnityGOAP.Exceptions;

namespace UnityGOAP.Examples.Actions {
    public class TeleportToAction : EntityAction<GroundEntity>, IGOAPInitListener {
        protected override float CalculateCost(GOAPAgent agent, GroundEntity entity) {
            var targetPos = entity.EntityState.GetValue(StateVariables.TargetLocation);
            //Since we are not doing pathfinding, this is merely an estimative.
            return Vector3.Distance(targetPos, entity.Position);
        }


        public override float CalculateMotivation(GOAPAgent agent) {
            return 0.1F;
        }

        public override IEnumerable<Precondition> GetPreconditions() {
            //No preconditions
            yield break;
        }

        public override bool SatisfiesPrecondition(Precondition precondition) {
            return precondition is LocationPrecondition;
        }

        public void OnInit(GOAPAgent agent) {
            var entity = agent.EntityStateProvider as GroundEntity;
            if (entity == null) {
                //Since this is only an example and the only known provider is Entity, this is "safe"
                //If you can to use this as a base, you can easily modify
                throw new WTFException();
            }
            var targetPos = entity.EntityState.GetValue(StateVariables.TargetLocation);
            //We are not doing pathfinding, let's just teleport the entity to the target location
            //Here is where you would set the pathfinding target on a real example tho :D
            entity.Teleport(targetPos);
        }
    }
}