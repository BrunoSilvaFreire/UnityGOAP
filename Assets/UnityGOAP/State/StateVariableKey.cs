namespace UnityGOAP.State {
    /// <summary>
    /// Defines an immutable unique key for an entity state variable.
    /// <para/>
    /// Note that this does <b>NOT</b> contain the actual value of a varible in an entity. This is merely 
    /// an identifier which can be used to get the actual value using 
    /// <see cref="UnityGOAP.State.EntityState.GetValue{T}"/>. 
    /// </summary>
    /// <typeparam name="T">The type of the variable.</typeparam>
    public struct StateVariableKey<T> {
        public readonly string Key;
        public readonly T DefaultValue;

        public StateVariableKey(string key, T defaultValue = default(T)) {
            Key = key;
            DefaultValue = defaultValue;
        }

        public override string ToString() {
            return string.Format("StateVariableKey<{0}>(Key: {1}, DefaultValue: {2})", typeof(T).Name, Key, DefaultValue);
        }
    }
}