using UnityEngine;
using UnityGOAP.State;

namespace UnityGOAP.Examples {
    public class GroundEntity : Entity { }

    public class AirEntity : Entity { }

    public abstract class Entity : EntityStateProvider {
        public string Name;

        public float MinimumHearableDistance;

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