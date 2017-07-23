using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace YenensTale {
    public class Sword : MonoBehaviour, IWeapon, IProjectileWeapon {

        private Animator animator;
        public List<BaseStat> Stats { get; set; }

        public Transform ProjectileSpawn { get; set; }
        Lightning lightning;

        void Start() {
            lightning = Resources.Load<Lightning>("Weapons/Projectiles/Lightning");
            animator = GetComponent<Animator>();
        }

        public void PerformAttack() {
            animator.SetTrigger("Base_Attack");
        }

        public void PerformSpecialAttack() {
            animator.SetTrigger("Special_Attack");
        }

        void OnTriggerEnter(Collider col) {
            //Debug.Log("Hit: " + col.name);
            if (col.tag == "Enemy") {
                col.GetComponent<IReceiveDamage>().ReceiveDamage(transform.forward, Stats[0].GetCalculatedStatValue(), gameObject);
            }
        }

        public void CastProjectile() {
            Lightning lightningInstance = (Lightning)Instantiate(lightning, ProjectileSpawn.position, ProjectileSpawn.rotation);
            lightningInstance.Direction = ProjectileSpawn.forward;
        }
    }
}