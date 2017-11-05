using UnityEngine;
using UnityGOAP.State;

namespace UnityGOAP.Examples {
    /// <summary>
    /// Utility class for getting common <see cref="StateVariableKey{T}"/>s.
    /// <para/>
    /// Although this is only an example, I recommend having one in your project.
    /// </summary>
    public static class StateVariables {
        public static readonly StateVariableKey<bool> IsSleeping = new StateVariableKey<bool>("sleeping");
        public static readonly StateVariableKey<Vector3> TargetLocation = new StateVariableKey<Vector3>("targetLocation");

        public static StateVariableKey<bool> IsTalkingTo(Entity other) {
            return new StateVariableKey<bool>(string.Format("talking.{0}", other.Name));
        }

        public static StateVariableKey<bool> IsAttacking(Entity target) {
            return new StateVariableKey<bool>("attacking." + target.Name);
        }
    }
}