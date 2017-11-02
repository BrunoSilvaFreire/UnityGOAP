using System;

namespace UnityGOAP.Exceptions {
    public class UnexpectedVariableTypeException : Exception {
        public UnexpectedVariableTypeException(Type expected, Type found, string key) : base(GetText(expected, found, key)) { }

        private static string GetText(Type expected, Type found, string key) {
            return string.Format(
                "Expected a variable of type '{0}' for key '{1}', but found {2}!" +
                " Maybe you have two StateVariableKeys with the same key string?",
                expected.Name,
                key,
                found.Name);
        }
    }
}