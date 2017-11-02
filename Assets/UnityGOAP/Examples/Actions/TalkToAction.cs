using System.Collections.Generic;
using UnityEngine;
using UnityGOAP.Examples.Actions.Entity;
using UnityGOAP.Examples.Preconditions.Location;
using UnityGOAP.Examples.Preconditions.Misc;
using UnityGOAP.Examples.Util;

namespace UnityGOAP.Examples.Actions {
    public class TalkToAction : EntityAction {
        private readonly NearEntityPreconditionWrapper nearPrecondition;

        public TalkToAction(Examples.Entity targetEntity) {
            nearPrecondition = new NearEntityPreconditionWrapper(targetEntity, GetMinimumDistance(targetEntity, Entity));
        }

        private static float GetMinimumDistance(Examples.Entity targetEntity, Examples.Entity entity) {
            var a = targetEntity.MinimumHearableDistance;
            var b = entity.MinimumHearableDistance;
            return Mathf.Min(a, b);
        }

        protected override float CalculateCost(GOAPAgent agent, Examples.Entity entity) {
            // This is for people at the discord servers I go to who never join the voice channel I'm at, not even for
            // a small chitchat, THERE IS NO COST PEOPLE, SEE?
            return 0;
        }

        public override bool IsPossible(GOAPAgent agent) {
            // Although this action requires two entities to be within the hearing range of one another, which requires 
            // entities to move themselves (if they are not already), this "location required" condition cannot 
            // negate the "talk to" action itself, an entity can talk to whichever entity it wants to (in most countries),
            // however, it does negate the "walk to" action, which is a depency of the "talk to" one (because we have 
            // the "nearPrecondition"). I'm not good with words so I hope you can understand this :D
            return true;
        }

        public override IEnumerable<Precondition> GetPreconditions() {
            yield return nearPrecondition.Precondition;
        }

        public override bool SatisfiesPrecondition(Precondition precondition) {
            return precondition is TalkingToPrecondition;
        }
    }
}