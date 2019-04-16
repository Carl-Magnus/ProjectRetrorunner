using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool buttonA;
    public static bool buttonUpA;
    public static bool buttonBasicA;
    bool buttonB;
    bool buttonX;
    bool buttonY;
    bool leftBumper;
    bool rightBumper;
    bool backButton;
    bool startButton;
    bool leftStickClick;
    bool rightStickClick;
    float leftStickXAxis;
    float leftStickYAxis;
    float rightStickXAxis;
    float rightStickYAxis;
    float dPadXAxis;
    float dPadYAxis;
    float leftTrigger;
    float rightTrigger;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        buttonA = Input.GetButtonDown("Jump");
        buttonUpA = Input.GetKeyUp("Jump");
        buttonBasicA = Input.GetKey("Jump");
        buttonB = Input.GetButtonDown("B");
        buttonX = Input.GetButtonDown("X");
        buttonY = Input.GetButtonDown("Y");
        leftBumper = Input.GetButtonDown("Left Bumper");
        rightBumper = Input.GetButtonDown("Right Bumper");
        backButton = Input.GetButtonDown("Back Button");
        startButton = Input.GetButtonDown("Start Button");
        leftStickClick = Input.GetButtonDown("Left Stick Click");
        rightStickClick = Input.GetButtonDown("Right Stick Click");
        leftStickXAxis = Input.GetAxisRaw("Left Stick X Axis");
        leftStickYAxis = Input.GetAxisRaw("Left Stick Y Axis");
        rightStickXAxis = Input.GetAxisRaw("Right Stick X Axis");
        rightStickYAxis = Input.GetAxisRaw("Right Stick Y Axis");
        dPadXAxis = Input.GetAxisRaw("D-Pad X Axis");
        dPadYAxis = Input.GetAxisRaw("D-Pad Y Axis");
        leftTrigger = Input.GetAxisRaw("Left Trigger");
        rightTrigger = Input.GetAxisRaw("Right Trigger");
    }


}
