using UnityEngine;
using System.Collections;

namespace YenensTale {
    public class WorldInteraction : MonoBehaviour {

        UnityEngine.AI.NavMeshAgent playerAgent;
        private Animator anim;

        void Start() {
            playerAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            anim = GetComponentInChildren<Animator>();
        }

        void Update() {
            if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                GetInteraction();
            anim.SetFloat("walk", playerAgent.desiredVelocity.magnitude);
        }

        void GetInteraction() {
            Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit interactionInfo;
            if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity)) {
                GameObject interactedObject = interactionInfo.collider.gameObject;
                if (interactedObject.tag == "Interactable Object") {
                    interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
                }
                else {
                    playerAgent.stoppingDistance = 0;
                    playerAgent.destination = interactionInfo.point;
                }
            }
        }
    }
}