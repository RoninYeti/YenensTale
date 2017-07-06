using System;
using System.Collections;
using UnityEngine;

namespace YenensTale {
    public class NormgBug : MonoBehaviour, IEnemy {

        public float currentHealth, power, toughness;
        public float maxhealth;
        //private UnityEngine.AI.NavMeshAgent navLook = null;
        //private Animator navAnim = null;
        //public GameObject playerWhere = null;
        public Transform bugStartPoint;
        //public Transform bugEndpoint;
        //private bool bugAttention = false;        
        //Vector3 heWent;
        //Quaternion thataWay;
        /*
        [SerializeField]
        private float navWaitTime = 10f;
        private float navWaitTimer = Mathf.Infinity;
        */
        public GameObject lightPost;
        public BugEnemy otherScript;
        public bugFirstMoves otherOtherScript;
        public UnityEngine.AI.NavMeshAgent navTesting = null;
        
        
        void Start() {
            currentHealth = maxhealth;
            //navLook = GetComponent<UnityEngine.AI.NavMeshAgent>();
            //navAnim = GetComponent<Animator>();
            //navLook.acceleration = 0;

            //===========you might need to add the below line back in=================
            transform.position = bugStartPoint.position;
            //otherScript = GetComponent<BugEnemy>();
            //otherOtherScript = GetComponent<bugFirstMoves>();
        }

        public void PerformAttack() {
            throw new NotImplementedException();
        }

        public void TakeDamage(int amount) {
            currentHealth -= amount;
            if (currentHealth <= 0)
                Die();
        }

        void Die() {
            Destroy(gameObject);
        }

        void FixedUpdate()
        {
            //navWaitTimer -= Time.deltaTime;
            /*if (bugAttention)
            {
                
                navLook.acceleration = 5;                
                navLook.SetDestination(bugEndpoint.transform.position);
                //float distance = Vector3.Distance(playerWhere.transform.position, transform.position);
                //heWent was previously direction
                heWent = (bugEndpoint.transform.position - transform.position).normalized;
                //Bug turns and looks at (player's direction)
                thataWay = Quaternion.LookRotation(heWent);
                transform.rotation = Quaternion.Slerp(transform.rotation, thataWay, Time.deltaTime * 5.0f);
                //startCount();  
                
                //navWaitTimer = navWaitTime;
                

            }*/

            if (Vector3.Distance(transform.position, lightPost.transform.position) <= 20)
            {
                //bugAttention = false;
                //navLook.acceleration = 0;
                otherOtherScript.enabled = false;
                //deactivate and reactivate the navmesh
                navTesting.enabled = false;
                navTesting.enabled = true;
                otherScript.enabled = true;
            }

            /*if (navWaitTimer <= 0)
            {
                //bugAttention = false;
                //BugCombat();




                navWaitTimer = Mathf.Infinity;
            }*/
        }

        

        /*public void BugCombat()
        {
            navLook.acceleration = 0;
            navLook.SetDestination(playerWhere.transform.position);
            //float distance = Vector3.Distance(playerWhere.transform.position, transform.position);
            //heWent was previously direction
            heWent = (playerWhere.transform.position - transform.position).normalized;
            //Bug turns and looks at (player's direction)
            thataWay = Quaternion.LookRotation(heWent);
            transform.rotation = Quaternion.Slerp(transform.rotation, thataWay, Time.deltaTime * 5.0f);
        }*/
        /*
        public void startCount()
        {
            navWaitTimer = navWaitTime;
        }*/

        public void BugMove()
        {
            //bugAttention = true;
            otherOtherScript.enabled = true;
            //navLook.acceleration = 5;
            //transform.position = Vector3.Lerp(bugStartPoint.position, bugEndpoint.position, 10f * Time.deltaTime);
            /*
            targetPosition += raiseBy[level++];
            lerpTimer = 0;
            */
        }
    }
}