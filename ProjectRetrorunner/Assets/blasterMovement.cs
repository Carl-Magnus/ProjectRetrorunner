using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blasterMovement : MonoBehaviour
{
    public Rigidbody2D blasterBody;
    public LayerMask groundCheck;

    public float blasterSpeed;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);

    }
}
