using System;
using UnityEngine;
using UnityGOAP.Examples.Preconditions.Entity;
using UnityGOAP.Examples.Preconditions.Location;

namespace UnityGOAP.Examples.Util {
    [Serializable]
    public sealed class NearEntityPreconditionWrapper : EntityPreconditionWrapper<NearEntityPrecondition, Entity> {
        private float distanceThreshold;

        public NearEntityPreconditionWrapper(Entity target, float distanceThreshold) : base(target) {
            this.distanceThreshold = distanceThreshold;
        }

        protected override Func<Entity, NearEntityPrecondition> LoadPreconditionCreator() {
            return Creator;
        }

        private NearEntityPrecondition Creator(Entity entity) {
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
    public abstract class EntityPreconditionWrapper<P, E> where P : EntityPrecondition<E> where E : Entity {
        [SerializeField]
        private E target;

        [SerializeField]
        private P precondition;

        private readonly Func<E, P> preconditionCreator;

        protected EntityPreconditionWrapper(E target) {
            this.target = target;
            preconditionCreator = LoadPreconditionCreator();
        }
        protected abstract Func<E, P> LoadPreconditionCreator();

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
            precondition = preconditionCreator(target);
        }
    }
}