using System;

namespace UnityGOAP.Exceptions {
    /// <summary>
    /// What a Terrible Failure exception, copied from google because I have no originality :c
    /// </summary>
    public class WTFException : Exception {
        public WTFException() : base("What a terrible failure") { }
    }
}