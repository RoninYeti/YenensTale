using System.Collections;
using UnityEngine;

namespace YenensTale {
    public class Lightning : MonoBehaviour {

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
            if (Vector3.Distance(spawnPosition, transform.position) >= Range) {
                Extinguish();
            }
        }

        void OnCollisionEnter(Collision col) {
            if (col.transform.tag == "Enemy") {
                col.transform.GetComponent<IEnemy>().TakeDamage(Damage);
            }
            Extinguish();
        }

        void Extinguish() {
            Destroy(gameObject);
        }
    }
}