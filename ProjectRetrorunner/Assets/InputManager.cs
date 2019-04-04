using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool buttonA = Input.GetButtonDown("A");
        bool buttonB = Input.GetButtonDown("B");
        bool buttonX = Input.GetButtonDown("X");
        bool buttonY = Input.GetButtonDown("Y");
        bool leftBumper = Input.GetButtonDown("Left Bumper");
        bool rightbumper = Input.GetButtonDown("Right Bumper");
        bool leftStickClick = Input.GetButtonDown("Left Stick click");
        bool rightStickClick = Input.GetButtonDown("Right Stick click");
        float leftStickXAxis = Input.GetAxisRaw("Left Stick X axis");
        float leftStickYAxis = Input.GetAxisRaw("Left Stick Y axis");
        float rightStickXAxis = Input.GetAxisRaw("Right Stick X axis");
        float rightStickYAxis = Input.GetAxisRaw("Right Stick Y axis");
        float dPadXAxis = Input.GetAxisRaw("D-Pad X axis");
        float dPadYAxis = Input.GetAxisRaw("D-Pad Y axis");
        float leftTrigger = Input.GetAxisRaw("Left Trigger");
        float rightTrigger = Input.GetAxisRaw("Right Trigger");
    }
}
