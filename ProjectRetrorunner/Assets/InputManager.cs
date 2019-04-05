using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update

    bool buttonA = Input.GetButtonDown("A");
    bool buttonB = Input.GetButtonDown("B");
    bool buttonX = Input.GetButtonDown("X");
    bool buttonY = Input.GetButtonDown("Y");
    bool leftBumper = Input.GetButtonDown("Left Bumper");
    bool rightBumper = Input.GetButtonDown("Right Bumper");
    bool backButton = Input.GetButtonDown("Back Button");
    bool startButton = Input.GetButtonDown("Start Button");
    bool leftStickClick = Input.GetButtonDown("Left Stick Click");
    bool rightStickClick = Input.GetButtonDown("Right Stick Click");
    float leftStickXAxis = Input.GetAxisRaw("Left Stick X Axis");
    float leftStickYAxis = Input.GetAxisRaw("Left Stick Y Axis");
    float rightStickXAxis = Input.GetAxisRaw("Right Stick X Axis");
    float rightStickYAxis = Input.GetAxisRaw("Right Stick Y Axis");
    float dPadXAxis = Input.GetAxisRaw("D-Pad X Axis");
    float dPadYAxis = Input.GetAxisRaw("D-Pad Y Axis");
    float leftTrigger = Input.GetAxisRaw("Left Trigger");
    float rightTrigger = Input.GetAxisRaw("Right Trigger");

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
