using System.Collections.Generic;
using UnityEngine;
using UnityGOAP.Examples.Actions.Entity;
using UnityGOAP.Examples.Preconditions.Location;

namespace UnityGOAP.Examples.Actions {
    public class FlyToAction : EntityAction<AirEntity>, IGOAPUpdateListener, IGOAPInitListener {
        private Vector3 currentTargetPosition;

        public override float CalculateMotivation(GOAPAgent agent) {
            return 2;
        }

        public override IEnumerable<Precondition> GetPreconditions() {
            yield break;
        }

        public override bool SatisfiesPrecondition(Precondition precondition) {
            return precondition is LocationPrecondition;
        }

        protected override float CalculateCost(GOAPAgent agent, AirEntity entity) {
            var targetPos = agent.EntityState.GetValue(StateVariables.TargetLocation);
            return Vector3.Distance(targetPos, entity.Position);
        }

        public void OnUpdate(GOAPAgent agent) {
            var e = agent.GetProviderAs<AirEntity>();
            e.FlyTowards(currentTargetPosition);
        }

        public void OnInit(GOAPAgent agent) {
            currentTargetPosition = agent.EntityState.GetValue(StateVariables.TargetLocation);
        }
    }
}