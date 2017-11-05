using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityGOAP.Exceptions;

namespace UnityGOAP.State {
    /// <summary>
    /// Represent's the state of a entity, which holds information about various <see cref="StateVariable"/>s 
    /// on this entity.
    /// </summary>
    [Serializable]
    public sealed class EntityState {
        [SerializeField]
        private List<StateVariable> stateVariables;

        public EntityState() {
            stateVariables = new List<StateVariable>();
        }

        public EntityState(IEnumerable<StateVariable> variables) {
            stateVariables = new List<StateVariable>(variables);
        }

        public EntityState Clone() {
            return new EntityState(stateVariables);
        }

        /// <summary>
        /// All the <see cref="StateVariable"/>s currently stored in this entity.
        /// </summary>
        public IEnumerable<StateVariable> AllVariables {
            get {
                return stateVariables;
            }
        }

        /// <summary>
        /// Sets the value of the provided <see cref="key"/> with the provided <see cref="value"/>.
        /// <para/>
        /// Any subsequent calls to <see cref="GetValue{T}"/> will return the provided <see cref="value"/>.
        /// Unless the value has been changed again to a different one.
        /// </summary>
        /// <param name="key">The key which the value will be stored to.</param>
        /// <param name="value">The new value of the key.</param>
        /// <typeparam name="T">The type of the <see cref="value"/>, must be the as as the key's typeparam.</typeparam>
        public void SetValue<T>(StateVariableKey<T> key, T value) {
            Debug.Log("Setting " + key + " to " + value);
            FindVariable(key).Value = value;
        }

        /// <summary>
        /// Get's the current value of the provided key on this entity, or the key's default 
        /// <see cref="StateVariableKey{T}.DefaultValue"/>.
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="T">The returned type, the same as the <see cref="key"/>'s type para</typeparam>
        /// <returns>
        /// The current value of this key for this entity, or the <see cref="key"/>'s 
        /// <see cref="StateVariableKey{T}.DefaultValue"/> if there is no coresponding 
        /// </returns>
        public T GetValue<T>(StateVariableKey<T> key) {
            var foundValue = FindVariable(key).Value;
            if (!(foundValue is T)) {
                throw new UnexpectedVariableTypeException(typeof(T), foundValue.GetType(), key.Key);
            }
            return (T) foundValue;
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
            //Check if found a coresponding variable, or create a new one with the default value
            return variable ?? (variable = CreateAndAdd(key));
        }

        private StateVariable CreateAndAdd<T>(StateVariableKey<T> key) {
            var v = new StateVariable(key.Key, key.DefaultValue);
            stateVariables.Add(v);
            return v;
        }
    }
}