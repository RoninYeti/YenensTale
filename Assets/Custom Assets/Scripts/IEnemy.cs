using System.Collections;
using UnityEngine;

public interface IEnemy
{
    void TakeDamage(int amount);
    void PerformAttack();
}
