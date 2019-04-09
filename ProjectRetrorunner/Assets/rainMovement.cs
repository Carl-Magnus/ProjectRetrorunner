using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainMovement : MonoBehaviour
{
    public Rigidbody2D body;

    private Vector2 direction;

    public ParticleSystem splash;

    public float fallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(direction.x, fallSpeed * direction.y);
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        splash.Play();
    }
}

