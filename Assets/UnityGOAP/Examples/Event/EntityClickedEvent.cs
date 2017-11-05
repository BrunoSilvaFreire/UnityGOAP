using UnityEngine.Events;

namespace UnityGOAP.Examples.Event {
    public class EntityClickedEvent : UnityEvent<Entity> {
        public static readonly EntityClickedEvent Instance = new EntityClickedEvent();
        private EntityClickedEvent() { }
    }
}