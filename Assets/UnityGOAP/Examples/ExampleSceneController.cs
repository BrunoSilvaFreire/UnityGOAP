using UnityEngine;
using UnityEngine.UI;
using UnityGOAP.Examples.Event;
using UnityGOAP.Examples.Goals;

namespace UnityGOAP.Examples {
    public class ExampleSceneController : MonoBehaviour {
        public Camera Camera;
        public float GeneralDistance = 1F;
        public Entity CurrentEntity;
        public Text DebugText;

        private void Start() {
            EntityClickedEvent.Instance.AddListener(OnEntityClicked);
            DebugText.text = "Listening to event!";
        }

        private void Update() {
            if (CurrentEntity & Input.GetKeyDown(KeyCode.Space)) {
                var ray = Camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit info;
                if (Physics.Raycast(ray, out info)) {
                    var collider = info.collider;
                    Goal goal = null;
                    var e = collider.GetComponentInParent<Entity>();
                    if (e) {
                        goal = new FollowEntityGoal(e, GeneralDistance);
                    }
                    goal = new GoToGoal(info.point, GeneralDistance);
                    if (goal != null) {
                        CurrentEntity.GOAPAgent.CurrentGoal = goal;
                        DebugText.text = string.Format("Set goal to {0}", goal);
                    }
                }
            }
        }

        private void OnEntityClicked(Entity arg0) {
            DebugText.text = string.Format("Selected entity {0} ({1})", arg0.Name, arg0);
            CurrentEntity = arg0;
        }
    }
}