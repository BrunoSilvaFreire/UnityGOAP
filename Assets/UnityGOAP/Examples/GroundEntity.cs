using UnityGOAP.Examples.Actions;

namespace UnityGOAP.Examples {
    public class GroundEntity : Entity {
        protected override void Configure(GOAPAgent goapAgent) {
            goapAgent.AddAction<TeleportToAction>();
        }
    }
}