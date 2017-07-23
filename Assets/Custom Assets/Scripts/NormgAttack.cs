using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YenensTale {
    public class NormgAttack : MonoBehaviour, IProjectile {

        public Vector3 Direction { get; set; }
        public float Range { get; set; }
        public int Damage { get; set; }

        Vector3 spawnPosition;

        void Start() {
            Range = 5f;
            Damage = 10;
            spawnPosition = transform.position;
            GetComponent<Rigidbody>().AddForce(Direction * 50f);
        }

        void Update() {
            if (Vector3.Distance(spawnPosition, transform.position) >= Range)
            {
                Extinguish();
            }
        }

        void OnTriggerEnter(Collider col) {
            IReceiveDamage receiveDamage = col.transform.GetComponent<IReceiveDamage>();
            if (receiveDamage != null)
            {
                receiveDamage.ReceiveDamage(Direction, Damage, gameObject);
            }
            Extinguish();
        }

        void Extinguish() {
            Destroy(gameObject);
        }
    }
}
