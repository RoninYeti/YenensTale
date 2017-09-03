using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YenensTale {
    public class BugEnemy : MonoBehaviour {

        private UnityEngine.AI.NavMeshAgent navLook = null;
        public Transform ProjectileSpawn;
        public Animator attackAnim;
        public GameObject playerLoc = null;
        Vector3 heWent;
        Quaternion thataWay;
        public float attackTime = 7;
        public float attackingTimer = 0;
        //the below float was used to simply show us usable parameters in the inspector
        public float distdisplay = 0;
        private float startAttackingTimer = 0;
        public AudioSource aSource;
        public AudioClip normgBugAttack;

        [SerializeField]
        private GameObject projectile;

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

            if (distance <= 20) {
                if (startAttackingTimer <= 5) {
                    startAttackingTimer += Time.deltaTime;
                }

                if (startAttackingTimer > 3) {
                    if (attackingTimer >= 7) {
                        attack();
                        attackingTimer = 0;
                    }

                    if (attackingTimer >= 2.7 && attackingTimer <= 2.72) {
                        normgAttack();
                    }
                }                                
            }
            distdisplay = distance;
        }

        public void attack() {
            attackAnim.SetTrigger("Bug Attack");
            aSource.PlayOneShot(normgBugAttack);
        }

        public void normgAttack() {
            GameObject projectileInstance = Instantiate(projectile, ProjectileSpawn.position, ProjectileSpawn.rotation);
            projectileInstance.GetComponent<IProjectile>().Direction = ProjectileSpawn.forward;
        }
    }
}
