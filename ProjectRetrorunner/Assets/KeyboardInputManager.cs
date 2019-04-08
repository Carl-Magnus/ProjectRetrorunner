using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputManager : MonoBehaviour
{
    public bool jumpKey;
    public bool jumpKeyDown;
    public bool jumpKeyUp;

    public bool blasterKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jumpKey = Input.GetKey(KeyCode.Space);
        jumpKeyDown = Input.GetKeyDown(KeyCode.Space);
        jumpKeyUp = Input.GetKeyUp(KeyCode.Space);

        blasterKey = Input.GetKeyDown(KeyCode.F);
    }
}
