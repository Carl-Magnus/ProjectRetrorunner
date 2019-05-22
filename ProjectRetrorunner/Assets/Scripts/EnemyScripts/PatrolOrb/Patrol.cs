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

    private Transform playerTransform;

    private Rigidbody2D body;

    public LayerMask whatIsGround;

    public GameObject bloodSplatter;

    private PlayerHealthSystem player;

    private Vector2 moveDirection;
    private PlayerMovement playerMovement;
    private EnemyAudioManager enemyAudioManager;

    public float knockBackTimer;

    public float knockBackForce;

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        enemyAudioManager = gameObject.GetComponent<EnemyAudioManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (knockBackTimer <= 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

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

        knockBackTimer -= Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        knockBackTimer = 1f;
        Instantiate(bloodSplatter, transform.position, Quaternion.identity);
        health -= damage;
        enemyAudioManager.PlayerHitByPlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Vector2 hitDirection = collision.transform.position - transform.position;
            hitDirection = hitDirection.normalized;

            if (hitDirection.x > 0)
            {
                hitDirection = new Vector2(1, 1);

                player.playerIsDamaged = true;
                player.PlayerGetDamaged(hitDirection);
            }

            else if (hitDirection.x < 0)
            {
                hitDirection = new Vector2(-1, 1);

                player.playerIsDamaged = true;
                player.PlayerGetDamaged(hitDirection);
            }
        }

        if (collision.collider.tag == "ground")
        {
            if (movingRight)
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


    public void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
