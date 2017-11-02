using UnityEngine;

namespace UnityGOAP.State {
    /// <summary>
    /// Represents a simple object which contains it's corresponding entity's state.
    /// <para/>
    /// Whether you'll make your entity class extend this or make it a separate component is up to you.
    /// </summary>
    public abstract class EntityStateProvider : MonoBehaviour {
        /// <summary>
        /// This corresponding entity's state.
        /// </summary>
        public EntityState EntityState;
    }
}