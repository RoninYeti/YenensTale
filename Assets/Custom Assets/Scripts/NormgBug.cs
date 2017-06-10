using System;
using System.Collections;
using UnityEngine;

namespace YenensTale
{
    public class NormgBug : MonoBehaviour, IEnemy
    {
        public float currentHealth, power, toughness;
        public float maxhealth;

        void Start()
        {
            currentHealth = maxhealth;
        }

        public void PerformAttack()
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
                Die();
        }

        void Die()
        {
            Destroy(gameObject);
        }
    }
}