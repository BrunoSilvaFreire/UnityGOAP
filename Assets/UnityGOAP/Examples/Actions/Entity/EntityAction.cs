namespace UnityGOAP.Examples.Actions.Entity {
    public abstract class EntityAction : EntityAction<Examples.Entity> { }

    public abstract class EntityAction<E> : Action where E : Examples.Entity {
        public E Entity;
        protected virtual void OnInit(GOAPAgent agent, E entity) { }
        protected virtual void OnUpdate(GOAPAgent agent, E entity) { }
        protected virtual void OnTerminate(GOAPAgent agent, E entity) { }
        protected abstract float CalculateCost(GOAPAgent agent, E entity);

        public sealed override float CalculateCost(GOAPAgent agent) {
            return CalculateCost(agent, GetEntity(agent));
        }

        public sealed override void OnInit(GOAPAgent agent) {
            OnInit(agent, GetEntity(agent));
        }

        public sealed override void OnUpdate(GOAPAgent agent) {
            OnUpdate(agent, GetEntity(agent));
        }

        public sealed override void OnTerminate(GOAPAgent agent) {
            OnTerminate(agent, GetEntity(agent));
        }

        public override bool IsPossible(GOAPAgent agent) {
            return agent.EntityStateProvider is E;
        }

        private static E GetEntity(GOAPAgent agent) {
            return (E) agent.EntityStateProvider;
        }
    }
}