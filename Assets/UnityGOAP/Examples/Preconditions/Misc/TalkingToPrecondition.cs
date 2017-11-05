namespace UnityGOAP.Examples.Preconditions.Misc {
    public class TalkingToPrecondition : TargetablePrecondition<Examples.Entity> {
        public override bool IsMet(GOAPAgent agent) {
            return agent.EntityState.GetValue(StateVariables.IsTalkingTo(Target));
        }
    }
}