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
    private float startRunSpeed;
    public float jumpForce;
    public float maxWallSlideSpeed;
    public float feetRadiusCheck;
    public float leftHandRadiusCheck;
    public float rightHandRadiusCheck;
    private float jumpTimeCounter;
    public float jumpTime;
    public float dashTime;
    public float dashSpeed;
    private float dashTimeReset;

    private bool isJumping;
    private bool isGrounded;
    public bool isDashing;
    public bool isLeftWallSliding;
    public bool isRightWallSliding;

    // Start is called before the first frame update
    void Start()
    {
        //Hänvisar till spelarens egen animation controller
        anim = GetComponent<Animator>();
        jumpReset = extraJumps;
        dashTimeReset = dashTime;
        startRunSpeed = runSpeed;
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

        WallJump();
        Dash();
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

        if (moveInput > 0 || moveInput < 0)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }
    
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

    public void FlipCharacterLeft()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
    }

    public void FlipCharacterRight()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
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

    public void Dash()
    {
        if (isDashing)
        {
            if (dashTime > 0)
            {
                dashTime -= Time.deltaTime;

                runSpeed = dashSpeed;
                gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            }

            else
            {
                runSpeed = startRunSpeed;
                isDashing = false;
                dashTime = dashTimeReset;
                gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
            }
        }
    }

    private void WallJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isLeftWallSliding && !isJumping)
        {
            isJumping = true;

            playerBody.velocity = new Vector2(wallJumpClimb.x, wallJumpClimb.y);

        }

        else if (Input.GetKeyDown(KeyCode.Space) && isRightWallSliding && !isJumping)
        {
            isJumping = true;

            playerBody.velocity = new Vector2(-wallJumpClimb.x, wallJumpClimb.y);
        }
    }

    public IEnumerator KnockBack(float knockDur, float knockbackPwr, Vector2 knockbackDir)
    {
        float timer = 0;

        while(knockDur > timer)
        {
            timer += Time.deltaTime;

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockbackDir.x * -150, knockbackDir.y * knockbackPwr));
        }

        yield return 0;
    }
}
