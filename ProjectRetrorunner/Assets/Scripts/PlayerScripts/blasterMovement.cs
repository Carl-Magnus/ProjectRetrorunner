using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blasterMovement : MonoBehaviour
{
    public Rigidbody2D blasterBody;
    public LayerMask groundCheck;

    public float blasterSpeed;

    public int blasterDamage;
    // Start is called before the first frame update
    void Start()
    {
        blasterBody.velocity = transform.right * blasterSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    private void EnemyHit()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Rain")
        {
            Physics2D.IgnoreLayerCollision(11, 12);
        }

        else if (collision.collider.tag == "Player")
        {
            Physics2D.IgnoreLayerCollision(10, 12);
        }

        else if (collision.collider.tag == "Enemy")
        {
            collision.collider.GetComponent<Patrol>().TakeDamage(blasterDamage);
            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

    }
}
