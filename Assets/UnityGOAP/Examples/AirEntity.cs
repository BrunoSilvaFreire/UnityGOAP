using UnityEngine;
using UnityGOAP.Examples.Actions;

namespace UnityGOAP.Examples {
    public class AirEntity : GroundEntity {
        public float FlySpeed = 1;

        protected override void Configure(GOAPAgent goapAgent) {
            base.Configure(goapAgent);
            goapAgent.AddAction<FlyToAction>();
        }

        public void FlyTowards(Vector3 currentTargetPosition) {
            transform.position += currentTargetPosition * FlySpeed * Time.deltaTime;
        }
    }
}