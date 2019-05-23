using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerMovement movement;
    private CyberBlaster blaster;
    private PlayerAttack attack;
    private PlayerAudioManager playerAudioManager;

    // Start is called before the first frame update
    void Start()
    {
        movement = gameObject.GetComponent<PlayerMovement>();
        blaster = gameObject.GetComponent<CyberBlaster>();
        attack = gameObject.GetComponent<PlayerAttack>();
        playerAudioManager = gameObject.GetComponent<PlayerAudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!movement.isLeftWallSliding && !movement.isRightWallSliding)
        {
            JumpLogic();
        }

        FlipCharacter();

        BlasterLogic();

        AttackLogic();

        DashLogic();

        WallJumpLogic();
    }

    //Logik för att få spelaren att hoppa
    private void JumpLogic()
    {
        if (Input.GetKeyDown(KeyCode.Space) && movement.extraJumps > 0)
        {
            movement.ExtraJump();
        }

        else if (Input.GetKeyDown(KeyCode.Space) && movement.extraJumps == 0)
        {
            movement.JumpFromGround();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            movement.VariableJump();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            movement.StopJumping();
        }
    }

    private void FlipCharacter()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            movement.FlipCharacterRight();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            movement.FlipCharacterLeft();
        }
    }

    //Logik för att spelaren ska kunna skjuta en CyberBlast
    private void BlasterLogic()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            blaster.Blast();
            playerAudioManager.PlayLaserShot();
        }
    }

    private void DashLogic()
    {
        if (Input.GetKeyDown(KeyCode.G) && !movement.isDashing)
        {
            playerAudioManager.PlayDashSound();
            movement.isDashing = true;
            attack.DashAttack();
        }
    }

    public void AttackLogic()
    {
        if (Input.GetKey(KeyCode.L))
        {
            playerAudioManager.PlayAttackSound();
            attack.Attack();
        }
        
    }

    public void WallJumpLogic()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.WallJump();
        }
    }
}
