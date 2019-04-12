using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerMovement movement;
    public CyberBlaster blaster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!movement.isLeftWallSliding && !movement.isRightWallSliding)
        {
            JumpLogic();
            
        }
        BlasterLogic();
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

    private void DashLogic()
    {
        

    }

    //Logik för att spelaren ska kunna skjuta en CyberBlast
    private void BlasterLogic()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            blaster.Blast();
        }
    }
}
