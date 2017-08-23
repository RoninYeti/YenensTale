using UnityEngine;
using System.Collections;

namespace YenensTale {
    public class WorldInteraction : MonoBehaviour {

        UnityEngine.AI.NavMeshAgent playerAgent;
        private Animator anim;
        Interactable goalInteraction;
        [SerializeField]
        private float interactionDistance = 3.0f;

        void Start() {
            playerAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            anim = GetComponentInChildren<Animator>();
        }

        void Update() {
            if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                GetInteraction();
            anim.SetFloat("walk", playerAgent.desiredVelocity.magnitude);
            
            if (goalInteraction != null && (transform.position - goalInteraction.transform.position).magnitude < interactionDistance) {
                goalInteraction.Interact();
                goalInteraction = null;
            }
        }

        void GetInteraction() {
            Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit interactionInfo;

            if (Physics.Raycast(interactionRay, out interactionInfo, 850)) {
                GameObject interactedObject = interactionInfo.collider.gameObject;
                //NOTE: HACK.
                goalInteraction = interactedObject.GetComponent<Interactable>();
                //else {
                playerAgent.stoppingDistance = 0;
                playerAgent.destination = interactionInfo.point;
                //}
            }
        }
    }
}