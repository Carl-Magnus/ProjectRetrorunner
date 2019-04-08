using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;

    public Transform playerFeet;
    public Transform leftHand;
    public Transform rightHand;

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
    public float leftHandRadiusCheck;
    public float rightHandRadiusCheck;
    private float jumpTimeCounter;
    public float jumpTime;

    private bool isJumping;
    private bool isGrounded;
    public bool isLeftWallSliding;
    public bool isRightWallSliding;

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
        isLeftWallSliding = Physics2D.OverlapCircle(leftHand.position, leftHandRadiusCheck, whatIsGround);
        isRightWallSliding = Physics2D.OverlapCircle(rightHand.position, rightHandRadiusCheck, whatIsGround);

        if (isGrounded)
        {
            extraJumps = jumpReset;
        }

        //WallJump();
    }

    private void FixedUpdate()
    {
        CharacterMovement();
        WallSlide();
        FlipCharacter();
        WallJump();

    }

    //Metod som tar in input ifrån om man rör sig åt vänster eller höger på en horisontella axeln, och multiplicerar värdet med runSpeed. Resulterar i att karaktärern rör sig höger respektive vänster.
    private void CharacterMovement()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        playerBody.velocity = new Vector2(moveInput * runSpeed, playerBody.velocity.y);
    }

    private void Jump()
    {
        playerBody.velocity = Vector2.up * jumpForce;
    }

    public void StopJumping()
    {
        isJumping = false;
    }

    public void VariableJump()
    {
        if (isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                Jump();
                jumpTimeCounter -= Time.deltaTime;
            }

            else
            {
                isJumping = false;
            }
        }
    }

    public void JumpFromGround()
    {
        if (isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            Jump();
        }

    }

    public void ExtraJump()
    {
        if (extraJumps > 0)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            Jump();
            extraJumps--;
        }
    }

    private void FlipCharacter()
    {

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

        else if (isRightWallSliding && playerBody.velocity.y < 0)
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
        if (Input.GetKeyDown(KeyCode.Space) && isLeftWallSliding && !isJumping)
        {
            isJumping = true;

            playerBody.velocity = new Vector2(jumpForce * wallJumpClimb.x, wallJumpClimb.y);

        }

        else if (Input.GetKeyDown(KeyCode.Space) && isRightWallSliding && !isJumping)
        {
            isJumping = true;

            playerBody.velocity = new Vector2(jumpForce * -wallJumpClimb.x, wallJumpClimb.y);
        }
    }
}
