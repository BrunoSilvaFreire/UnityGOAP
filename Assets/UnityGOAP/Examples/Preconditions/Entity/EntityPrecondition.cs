namespace UnityGOAP.Examples.Preconditions.Entity {
    /// <summary>
    /// Represents an <see cref="EntityPrecondition{E}"/> about any type entity.
    /// </summary>
    public abstract class EntityPrecondition : EntityPrecondition<Examples.Entity> {
        protected EntityPrecondition() { }
        protected EntityPrecondition(Examples.Entity entity) : base(entity) { }
    }

    /// <summary>
    /// Represents a condition that revolves around a specific Entity (of type E)
    /// </summary>
    public abstract class EntityPrecondition<E> : Precondition where E : Examples.Entity {
        public E Entity;
        protected EntityPrecondition() { }
        protected EntityPrecondition(E entity) {
            Entity = entity;
        }
    }
}