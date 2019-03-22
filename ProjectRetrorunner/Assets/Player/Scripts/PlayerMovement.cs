using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;

    private float moveInput;
    public float runSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CharacterMovement();
    }

    //Metod som tar in input ifrån om man rör sig åt vänster eller höger på en horisontella axeln, och multiplicerar värdet med runSpeed. Resulterar i att karaktärern rör sig höger respektive vänster.
    private void CharacterMovement()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        playerBody.velocity = new Vector2(moveInput * runSpeed, playerBody.velocity.y);
    }
}
