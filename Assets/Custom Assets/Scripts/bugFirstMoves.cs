using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YenensTale {
    public class bugFirstMoves : MonoBehaviour {

        private UnityEngine.AI.NavMeshAgent navLook = null;
        public GameObject playerWhere = null;
        public Animator bugJump;
        public Transform bugEndpoint;
        Vector3 heWent;

        void Start() {
            navLook = GetComponent<UnityEngine.AI.NavMeshAgent>();
            bugJump.SetTrigger("Bug Jump");
        }

        void FixedUpdate() {
            navLook.acceleration = 5;
            navLook.speed = 500;
            navLook.SetDestination(bugEndpoint.transform.position);
            //heWent was previously direction
            heWent = (bugEndpoint.transform.position - transform.position).normalized;
        }
    }
}