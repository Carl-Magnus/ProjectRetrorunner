using System.Collections;
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

    public PlayerMovement playerMovement;

    private 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
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

            if (Input.GetKey(KeyCode.L))
            {
                playerAnim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whaIsEnemy);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Patrol>().TakeDamage(damage);
                }
            }
        }

        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }

    public void DashAttack()
    {
        if(playerMovement.isDashing == true)
        {
            
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(dashAttackPosition.position, dashAttackRange, whaIsEnemy);

            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Patrol>().TakeDamage(damage);                
            }
        }
    }
}
