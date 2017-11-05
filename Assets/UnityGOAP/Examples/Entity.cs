using UnityEngine;
using UnityGOAP.Examples.Event;
using UnityGOAP.State;

namespace UnityGOAP.Examples {
    public abstract class Entity : EntityStateProvider {
        public string Name;
        public float MinimumHearableDistance;
        public GOAPAgent GOAPAgent;

        private void Start() {
            Configure(GOAPAgent);
        }

        protected abstract void Configure(GOAPAgent goapAgent);

        private void OnMouseDown() {
            EntityClickedEvent.Instance.Invoke(this);
        }

        public Vector3 Position {
            get {
                return transform.position;
            }
        }

        public void Teleport(Vector3 targetPos) {
            transform.position = targetPos;
        }
    }
}