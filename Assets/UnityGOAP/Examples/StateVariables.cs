using UnityGOAP.State;

namespace UnityGOAP.Examples {
    public static class StateVariables {
        public static StateVariableKey<bool> IsTalkingTo(Entity other) {
            return new StateVariableKey<bool>("");
        }
    }
}