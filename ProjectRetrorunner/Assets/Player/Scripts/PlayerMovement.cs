using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;

    public Transform playerFeet;
    public Transform playerHand;

    public LayerMask whatIsGround;

    private Animator anim;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallJumpLeap;

    public int extraJumps;
    private int jumpReset;

    private float moveInput;
    private float wallDirectionX;
    public float runSpeed;
    public float jumpForce;
    public float maxWallSlideSpeed;
    public float feetRadiusCheck;
    public float handRadiusCheck;
    private float jumpTimeCounter;
    public float jumpTime;

    private bool isJumping;
    private bool isGrounded;
    private bool isLeftWallSliding;
    private bool isRightWallSliding;

    // Start is called before the first frame update
    void Start()
    {
        //Hänvisar till spelarens egen animation controller
        anim = GetComponent<Animator>();
        jumpReset = extraJumps;
    }

    // Update is called once per frame
    void Update()
    {
        //Kollar ifall spelarens fötter befinner sig på marken
        isGrounded = Physics2D.OverlapCircle(playerFeet.position, feetRadiusCheck, whatIsGround);

        //Kollar ifall spelarens hand befinner sig emot en vägg(Ground)
        isLeftWallSliding = Physics2D.OverlapCircle(playerHand.position, handRadiusCheck, whatIsGround);

        if (!isLeftWallSliding)
        {
            Jump();
        }

        if (isGrounded)
        {
            extraJumps = jumpReset;
        }

        WallJump();
    }

    private void FixedUpdate()
    {
        CharacterMovement();
        WallSlide();
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
        //Kollar ifall spelaren har extra hopp kvar. I så fall kan spelaren hoppa igen.
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            playerBody.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }

        //Kollar om spelaren står på marken, och gör så att man kan hoppa utan extra hopp
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            playerBody.velocity = Vector2.up * jumpForce;
        }

        //Sköter så spelarens hopp har olika höjd beroende på hur länge som spelaren håller inne Space
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                playerBody.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }

            else
            {
                isJumping = false;
            }
        }

        //Gör så att spelaren slutar att hoppa ifall man släpper Space
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    //Metod som saknar ner spelaren om hans hand kolliderar med en vägg och han rör sig nedåt
    private void WallSlide()
    {
        if (isLeftWallSliding && playerBody.velocity.y < 0)
        {
            isJumping = false;

            if (playerBody.velocity.y < maxWallSlideSpeed)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, -maxWallSlideSpeed);
            }
        }
    }

    private void WallJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isLeftWallSliding)
        {
            isJumping = true;

            playerBody.velocity = new Vector2(wallJumpClimb.x, wallJumpClimb.y);

        }
    }
}
