using System.Collections;
using UnityEngine;

namespace YenensTale {
    public interface IEnemy {
        void TakeDamage(int amount);
        void PerformAttack();
    }
}