using System.Collections.Generic;
using UnityEngine;
using UnityGOAP.Examples.Preconditions.Location;

namespace UnityGOAP.Examples.Goals {
    public class GoToGoal : Goal {
        public Vector3 Pos;
        public float MinDistance;

        public GoToGoal(Vector3 pos, float minDistance) {
            Pos = pos;
            MinDistance = minDistance;
        }

        public GoToGoal() { }

        public override IEnumerable<Precondition> GetCompletionPreconditions(GOAPAgent agent) {
            yield return new NearFixedLocationPrecondition(MinDistance, Pos);
        }
    }
}