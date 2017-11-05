using System;
using UnityEngine;
using UnityGOAP.Examples.Preconditions.Entity;
using UnityGOAP.Examples.Preconditions.Location;

namespace UnityGOAP.Examples.Util {
    [Serializable]
    public sealed class NearEntityPreconditionWrapper : EntityPreconditionWrapper<NearEntityPrecondition, Entity> {
        private float distanceThreshold;
        public NearEntityPreconditionWrapper() { }

        public NearEntityPreconditionWrapper(Entity target, float distanceThreshold) : base(target) {
            this.distanceThreshold = distanceThreshold;
        }

        protected override NearEntityPrecondition CreatePrecondition(Entity entity) {
            return new NearEntityPrecondition(entity, distanceThreshold);
        }


        public float DistanceThreshold {
            get {
                return distanceThreshold;
            }
            set {
                distanceThreshold = value;
                ReloadPrecondition();
            }
        }
    }

    /// <summary>
    /// Represents a wrapper that reloads the precondition everytime any parameter is changed
    /// </summary>
    /// <typeparam name="P"></typeparam>
    /// <typeparam name="E"></typeparam>
    public abstract class EntityPreconditionWrapper<P, E> where P : IEntityContainer<E> where E : Entity {
        public static T CreateWrapper<T>() where T : EntityPreconditionWrapper<P, E>, new() {
            var wrapper = new T();
            wrapper.ReloadPrecondition();
            return wrapper;
        }

        [SerializeField]
        private E target;

        [SerializeField]
        private P precondition;

        protected abstract P CreatePrecondition(E entity);
        protected EntityPreconditionWrapper() { }

        protected EntityPreconditionWrapper(E target) {
            this.target = target;
        }

        public P Precondition {
            get {
                return precondition;
            }
        }

        public E Target {
            get {
                return target;
            }
            set {
                target = value;
                ReloadPrecondition();
            }
        }

        protected void ReloadPrecondition() {
            precondition = CreatePrecondition(target);
        }
    }

    public interface IEntityContainer<E> where E : Entity {
        E Entity {
            get;
            set;
        }
    }
}