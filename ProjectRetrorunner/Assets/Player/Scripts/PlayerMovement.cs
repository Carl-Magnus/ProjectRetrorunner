using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;

    public Transform playerFeet;

    public LayerMask whatIsGround;

    private Animator anim;

    private float moveInput;
    public float runSpeed;
    public float jumpForce;
    public float feetRadiusCheck;

    private bool isJumping;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        //Hänvisar till spelarens egen animation controller
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Kollar ifall spelarens fötter befinner sig på marken
        isGrounded = Physics2D.OverlapCircle(playerFeet.position, feetRadiusCheck, whatIsGround);
        Jump();
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

    //Metod för att sköta spelarens förmåga att hoppa
    private void Jump()
    {
        //Kollar ifall spelaren är på marken när man klickar space. I så fall hoppar karaktären uppåt.
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            playerBody.velocity = Vector2.up * jumpForce;
        }
    }
}
