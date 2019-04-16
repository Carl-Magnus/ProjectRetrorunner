using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainMovement : MonoBehaviour
{
    public Rigidbody2D body;

    private Vector2 direction;

    public ParticleSystem splash;

    public GameObject splashEffect;

    public float fallSpeed;
    private float aliveTimer;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(0, -1);
        aliveTimer = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(direction.x, fallSpeed * direction.y);
        
    }

    private void FixedUpdate()
    {
        aliveTimer -= Time.deltaTime;

        if (aliveTimer < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Physics2D.IgnoreLayerCollision(10, 11);
        }

        else if (collision.collider.tag == "Rain")
        {
            Physics2D.IgnoreLayerCollision(11, 11);
        }

        else
        {
            CreateSplash();

            Destroy(gameObject);
        }
    }

    private void CreateSplash()
    {
        Instantiate(splashEffect, gameObject.transform);
    }
}

