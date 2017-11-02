using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGOAP.State {
    [Serializable]
    public class EntityState {
        [SerializeField]
        private List<StateVariable> stateVariables = new List<StateVariable>();

        public void SetValue<T>(StateVariableKey<T> key, T value) {
            FindVariable(key).Value = value;
        }

        public T GetValue<T>(StateVariableKey<T> key) {
            return (T) FindVariable(key).Value;
        }

        private StateVariable FindVariable<T>(StateVariableKey<T> key) {
            StateVariable variable = null;
            var expectedString = key.Key;
            //Search for an already existing variable
            foreach (var stateVariable in stateVariables) {
                if (stateVariable.Key.Equals(expectedString, StringComparison.InvariantCulture)) {
                    variable = stateVariable;
                }
            }
            return variable ?? (variable = new StateVariable(expectedString, key.DefaultValue));
        }
    }
}