﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPosition;
    public Transform dashAttackPosition;

    public LayerMask whaIsEnemy;

    public Animator playerAnim;

    private float timeBetweenAttack;
    public float startTimeBetweenAttack;
    public float attackRange;

    public float dashAttackRange;

    public int damage;

    private PlayerMovement playerMovement;



    // Start is called before the first frame update
    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenAttack -= Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }

    public void Attack()
    {
        if (timeBetweenAttack <= 0)
        {
            timeBetweenAttack = startTimeBetweenAttack;

            playerAnim.SetTrigger("attack");
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whaIsEnemy);

            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                if (enemiesToDamage[i].tag == "Enemy")
                {
                    enemiesToDamage[i].GetComponent<Patrol>().TakeDamage(damage);
                }

                if (enemiesToDamage[i].tag == "Sentry")
                {
                    enemiesToDamage[i].GetComponent<RotateAim>().TakeDamage(damage);
                }
            }
        }
    }

    public void DashAttack()
    {
        if (playerMovement.isDashing == true)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(dashAttackPosition.position, dashAttackRange, whaIsEnemy);

            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                if (enemiesToDamage[i].tag == "Enemy")
                {
                    enemiesToDamage[i].GetComponent<Patrol>().TakeDamage(damage);
                }

                if (enemiesToDamage[i].tag == "Sentry")
                {
                    enemiesToDamage[i].GetComponent<RotateAim>().TakeDamage(damage);
                }
            }
        }
    }
}
