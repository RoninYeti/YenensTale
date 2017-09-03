using System;
using System.Collections;
using UnityEngine;
using YenensTale;

namespace YenensTale {
    public class NormgBug : MonoBehaviour, IReceiveDamage {

        public float currentHealth, power, toughness;
        public float maxhealth;
        public Animator bugDeath;
        public GameObject bugEndPoint;
        public NormgBug mainScript;
        public BugEnemy otherScript;
        public bugFirstMoves otherOtherScript;
        public UnityEngine.AI.NavMeshAgent navTesting = null;
        public AudioSource aSource;
        public AudioClip normgBugDying;
        public AudioClip normgBugAttacked;

        void Start() {
            currentHealth = maxhealth; 
        }

        public void PerformAttack() {
            throw new NotImplementedException();
        }

        /*public void TakeDamage(int amount) {
            currentHealth -= amount;
            if (currentHealth <= 0)
                Die();
        }*/

        public void ReceiveDamage(Vector3 direction, float damage, GameObject source) {
            currentHealth -= damage;
            aSource.PlayOneShot(normgBugAttacked);
            if (currentHealth <= 0) Die();
        }

        void Die() {
            aSource.PlayOneShot(normgBugDying);
            bugDeath.SetTrigger("Bug Dead");
            mainScript.enabled = false;
            otherScript.enabled = false;
            otherOtherScript.enabled = false;
        }

        void FixedUpdate() {
            if (Vector3.Distance(transform.position, bugEndPoint.transform.position) <= 5f) {
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