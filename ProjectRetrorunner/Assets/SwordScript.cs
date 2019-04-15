using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public string enemyTag;
    private bool isPreparingActive;
    private bool isShieldActive;
    private bool isAttackActive;

    // Start is called before the first frame update
    void Start()
    {
        isAttackActive = false;
        isPreparingActive = false;
        isShieldActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (isPreparingActive)
            {
                Attack();
            }
            else
            {
                PrepareAttack();
            }
        }

        if (Input.GetKeyDown(KeyCode.P) && !isAttackActive)
        {
            Shield();
        }
    }

    void PrepareAttack()
    {
        isPreparingActive = true;
        Debug.Log("Preparing");
    }

    void Attack()
    {
        isAttackActive = true;
        Debug.Log("Attacking");
    }

    void Shield()
    {
        isShieldActive = true;
        Debug.Log("Shielding");
    }
}
