namespace UnityGOAP.State {
    public struct StateVariableKey<T> {
        public readonly string Key;
        public readonly T DefaultValue;

        public StateVariableKey(string key, T defaultValue = default(T)) {
            Key = key;
            DefaultValue = defaultValue;
        }
    }
}