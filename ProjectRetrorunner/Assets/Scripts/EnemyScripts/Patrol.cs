using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;

    public int health;

    private bool movingRight = true;

    public Transform groundDetection;

    public LayerMask whatIsGround;

    public GameObject bloodSplatter;
    public GameObject player;

    private Vector2 moveDirection;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        Death();

        RaycastHit2D groundDetect = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundDetect.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingRight = true;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Instantiate(bloodSplatter, transform.position, Quaternion.identity);
        health -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            player.GetComponent<HealthSystem>().isDamaged = true;
            player.GetComponent<HealthSystem>().Damaged();
            player.GetComponent<PlayerMovement>().isKnockedUp = true;
            player.GetComponent<PlayerMovement>().KnockUp();
        }
    }


    public void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
