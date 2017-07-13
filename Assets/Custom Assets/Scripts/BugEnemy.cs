using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YenensTale {
    public class BugEnemy : MonoBehaviour { 
    
        private UnityEngine.AI.NavMeshAgent navLook = null;
        //private Animator navigAnimation = null;
        public GameObject playerLoc = null;
        Vector3 heWent;
        Quaternion thataWay;

        void Start() {
            navLook = GetComponent<UnityEngine.AI.NavMeshAgent>();
            transform.position = transform.position;
        }

        void FixedUpdate() {
            navLook.acceleration = 0;
            navLook.SetDestination(playerLoc.transform.position);
            //float distance = Vector3.Distance(playerWhere.transform.position, transform.position);
            //heWent was previously direction
            heWent = (playerLoc.transform.position - transform.position).normalized;
            //Bug turns and looks at (player's direction)
            thataWay = Quaternion.LookRotation(heWent);
            transform.rotation = Quaternion.Slerp(transform.rotation, thataWay, Time.deltaTime * 5.0f);
        }
    }
}
