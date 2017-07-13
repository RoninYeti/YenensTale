using System;
using System.Collections;
using UnityEngine;

namespace YenensTale {
    public class NormgBug : MonoBehaviour, IEnemy {

        public float currentHealth, power, toughness;
        public float maxhealth;
        public Animator bugDeath;
        //public Transform bugStartPoint;
        public GameObject lightPost;
        public BugEnemy otherScript;
        public bugFirstMoves otherOtherScript;
        public UnityEngine.AI.NavMeshAgent navTesting = null;
        
        void Start() {
            currentHealth = maxhealth;
            //transform.position = bugStartPoint.position;  
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
            //Destroy(gameObject);
            bugDeath.SetTrigger("Bug Dead");
        }

        void FixedUpdate() {
            if (Vector3.Distance(transform.position, lightPost.transform.position) <= 20) {
                otherOtherScript.enabled = false;
                //deactivate and reactivate the navmesh
                navTesting.enabled = false;
                navTesting.enabled = true;
                otherScript.enabled = true;
            }
        }

        public void BugMove() {
            otherOtherScript.enabled = true;
        }
    }
}