using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public static bool combatMode;

    // Start is called before the first frame update
    void Start()
    {
        combatMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C) && combatMode == false)
        {
            combatMode = true;
        }
        else if(Input.GetKeyUp(KeyCode.C) && combatMode == true)
        {
            combatMode = false;
        }
    }
}
