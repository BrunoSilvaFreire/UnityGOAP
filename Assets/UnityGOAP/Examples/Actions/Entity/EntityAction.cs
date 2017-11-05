using UnityGOAP.State;

namespace UnityGOAP.Examples.Actions.Entity {
    public abstract class EntityAction : EntityAction<Examples.Entity> { }

    public abstract class EntityAction<E> : Action where E : Examples.Entity {
        public E Entity;
        protected abstract float CalculateCost(GOAPAgent agent, E entity);

        public sealed override float CalculateCost(GOAPAgent agent) {
            return CalculateCost(agent, GetEntity(agent));
        }


        public override bool IsPossible(GOAPAgent agent, EntityState state) {
            return agent.EntityStateProvider is E;
        }

        private static E GetEntity(GOAPAgent agent) {
            return (E) agent.EntityStateProvider;
        }
    }
}