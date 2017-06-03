using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Sword : MonoBehaviour, IWeapon, IProjectileWeapon
{
    private Animator animator;
    public List<BaseStat> Stats { get; set; }

    public Transform ProjectileSpawn { get; set; }
    Lightning lightning;
    
    void Start()
    {
        lightning = Resources.Load<Lightning>("Weapons/Projectiles/Lightning");
        animator = GetComponent<Animator>();
    }

    public void PerformAttack()
    {
        animator.SetTrigger("Base_Attack");
    }

    public void PerformSpecialAttack()
    {
        animator.SetTrigger("Special_Attack");
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("Hit: " + col.name);
        if (col.tag == "Enemy")
        {
            col.GetComponent<IEnemy>().TakeDamage(Stats[0].GetCalculatedStatValue());
        }
    }

    public void CastProjectile()
    {
        Lightning lightningInstance = (Lightning)Instantiate(lightning, ProjectileSpawn.position, ProjectileSpawn.rotation);
        lightningInstance.Direction = ProjectileSpawn.forward;
    }
}
