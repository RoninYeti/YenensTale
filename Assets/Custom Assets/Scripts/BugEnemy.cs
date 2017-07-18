using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YenensTale {
    public class BugEnemy : MonoBehaviour { 
    
        private UnityEngine.AI.NavMeshAgent navLook = null;
        public Animator attackAnim;
        public GameObject playerLoc = null;
        Vector3 heWent;
        Vector3 stallPoint;
        Quaternion thataWay;
        public float attackTime = 5;
        private float attackingTimer = 0;
        //the below float was used to simply show us usable parameters in the inspector
        public float distdisplay = 0;

        void Start() {
            navLook = GetComponent<UnityEngine.AI.NavMeshAgent>();
            transform.position = transform.position;
        }

        void FixedUpdate() {
            attackingTimer += Time.deltaTime;
            navLook.acceleration = 0;
            navLook.SetDestination(playerLoc.transform.position);
            float distance = Vector3.Distance(playerLoc.transform.position, transform.position);
            //heWent was previously direction
            heWent = (playerLoc.transform.position - transform.position).normalized;
            //Bug turns and looks at (player's direction)
            thataWay = Quaternion.LookRotation(heWent);
            transform.rotation = Quaternion.Slerp(transform.rotation, thataWay, Time.deltaTime * 5.0f);
            
            if (attackingTimer >= attackTime && distance <= 20) {
                StallPoint();
                thataWay = Quaternion.LookRotation(stallPoint);
                attack();

                if (attackingTimer >= 15) {
                    attackingTimer = 0;
                }
            }
            distdisplay = distance;
        }

        public void StallPoint() {
            stallPoint = heWent;
        }

        public void attack() {
            attackAnim.SetTrigger("Bug Attack");
            //add lightning stuff here
        }
    }
}
