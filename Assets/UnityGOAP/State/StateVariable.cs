using System;
using UnityEngine;

namespace UnityGOAP.State {
    /// <summary>
    /// Holds information about a <see cref="StateVariableKey{T}"/> for a specific entity.
    /// The type of the <see cref="Value"/> property is supposed to be the same as it's key's type parameter, which means, if the 
    /// variable is matched by the following key:
    /// <code>
    /// StateVariableKey(bool) isSleeping = new StateVariableKey(bool)("sleeping"); 
    /// </code>
    /// It's value will be a bool.
    /// </summary>
    [Serializable]
    public sealed class StateVariable {
        [SerializeField]
        private string key;

        [SerializeField]
        private object value;

        /// <summary>
        /// Serialization constructor
        /// </summary>
        public StateVariable() { }

        /// <summary>
        /// Creates
        /// </summary>
        /// <param name="key">The key this variable coresponds to.</param>
        /// <param name="value">The value of this variable</param>
        public StateVariable(string key, object value) {
            this.key = key;
            this.value = value;
        }

        public string Key {
            get {
                return key;
            }
        }

        /// <summary>
        /// The current value of this variable's key on this variable's entity.
        /// </summary>
        public object Value {
            get {
                return value;
            }
            set {
                this.value = value;
            }
        }
    }
}