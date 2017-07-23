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
        private float attackTime = 7;
        private float attackingTimer = 0;
        //the below float was used to simply show us usable parameters in the inspector
        public float distdisplay = 0;
        [SerializeField]
        private GameObject projectile;
        //Lightning lightning;

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
                attack();

                if (attackingTimer >= 7) {
                    attackingTimer = 0;
                }
            }
            distdisplay = distance;
        }

        public void attack() {
            attackAnim.SetTrigger("Bug Attack");
            //StartCoroutine(attackDelay());
            GameObject projectileInstance = Instantiate(projectile, ProjectileSpawn.position, ProjectileSpawn.rotation);
            projectileInstance.GetComponent<IProjectile>().Direction = ProjectileSpawn.forward;
        }

        /*public IEnumerator attackDelay() {
            yield return new WaitForSeconds(3f);
        }*/
    }
}
