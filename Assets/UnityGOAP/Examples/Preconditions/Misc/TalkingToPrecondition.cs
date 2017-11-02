namespace UnityGOAP.Examples.Preconditions.Misc {
    public class TalkingToPrecondition : TargetablePrecondition<Examples.Entity> {
        public override bool IsMet() {
            return Entity.EntityState.GetValue(StateVariables.IsTalkingTo(Target));
        }
    }
}