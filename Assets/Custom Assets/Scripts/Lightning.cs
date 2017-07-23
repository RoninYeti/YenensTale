using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YenensTale {
    public class Lightning : MonoBehaviour, IProjectile {

        public float Range { get; set; }
        public Vector3 Direction { get; set; }
        public int Damage { get; set; }

        [SerializeField]
        float destroyTime;
        float destroyTimer;

        Vector3 spawnPosition;

        void Start() {
            destroyTimer = destroyTime;
            //Range = 5f;
            Damage = 10;
            spawnPosition = transform.position;
            //GetComponent<Rigidbody>().AddForce(Direction * 50f);
        }

        void Update() {
            destroyTime -= Time.deltaTime;
            if (destroyTime <= 0) {
                Extinguish();
            }
            if (Vector3.Distance(spawnPosition, transform.position) >= Range) {
                Extinguish();
            }
        }

        void OnTriggerEnter(Collider col) {
            IReceiveDamage receiveDamage = col.transform.GetComponent<IReceiveDamage>();
            if (receiveDamage != null) {
                receiveDamage.ReceiveDamage(Direction, Damage, gameObject);
                Debug.Log("This Worked!");
                Extinguish();
            }
        }

        void Extinguish() {
            Destroy(gameObject);
        }
    }
}