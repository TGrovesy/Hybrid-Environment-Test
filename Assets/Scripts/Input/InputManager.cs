using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR.Interaction;

public class InputManager : MonoBehaviour
{

    public GameObject debugCube;

    //Trigger
    private bool rightTriggerDown = false;
    private bool leftTriggerDown = false;

    //Face Buttons
    private bool leftADown = false;
    private bool leftBDown = false;
    private bool rightADown = false;
    private bool rightBDown = false;

    //Face analog
    private float rightThumbAnalogX = 0.0f;
    private float rightThumbAnalogY = 0.0f;
    private float leftThumbAnalogX = 0.0f;
    private float leftThumbAnalogY = 0.0f;

    //Grips
    private bool leftGripDown = false;
    private bool rightGripDown = false;

    //debug
    private bool leftHandInput = false;

    //Controllers
    private GameObject rightController;
    private GameObject leftController;

    // Start is called before the first frame update
    void Start()
    {
        rightController = GameObject.Find("Controller (right)");
        leftController = GameObject.Find("Controller (left)");
    }

    // Update is called once per frame
    void Update()
    {/*
        if (rightTriggerDown || leftTriggerDown   || leftADown || leftBDown || rightADown || rightBDown) {
            if (leftHandInput) {
                Instantiate(debugCube, leftController.transform.position, leftController.transform.rotation);
            } else {
                Instantiate(debugCube, rightController.transform.position, rightController.transform.rotation);
            }
        }*/
    }


    /*
     * Set right trigger down
     */
    public void SetRightTriggerDown() {
        Debug.Log("Right Trigger Click");
        rightTriggerDown = true;
        leftHandInput = false;
    }

    /*
     * Set right trigger up
     */
    public void SetRightTriggerUp() {
        rightTriggerDown = false;
        leftHandInput = false;
    }
    public bool GetRightTriggerDown() {
        return rightTriggerDown;
    }


    /*
     * Set left trigger down
     */
    public void SetLeftTriggerDown() {

        leftTriggerDown = true;
        leftHandInput = true;
    }

    /*
     * Set right trigger up
     */
    public void SetLeftTriggerUp() {
        leftTriggerDown = false;
        leftHandInput = true;
    }

    public bool GetLeftTriggerDown() {
        return leftTriggerDown;
    }


    /*
     * Left A down
     */
    public void SetLeftAButtonDown() {
        leftADown = true;
        leftHandInput = true;
    }

    /*
     * Left A up
     */
    public void SetLeftAButtonUp() {
        leftADown = false;
        leftHandInput = true;
    }

    public bool GetLeftADown() {
        return leftADown;
    }

    /*
    * Left B down
    */
    public void SetLeftBButtonDown() {
        leftBDown = true;
        leftHandInput = true;
    }

    /*
     * Left B up
     */
    public void SetLeftBButtonUp() {
        leftBDown = false;
        leftHandInput = true;
    }

    public bool GetLeftBDown() {
        return leftBDown;
    }

    /*
     * Right A down
     */
    public void SetRightAButtonDown() {
        rightADown = true;

        leftHandInput = false;
    }

    /*
     * Right A up
     */
    public void SetRightAButtonUp() {
        rightADown = false;
        leftHandInput = false;

    }

    public bool GetRightADown() {
        return rightADown;
    }

    /*
    * Right B down
    */
    public void SetRightBButtonDown() {
        rightBDown = true;
        leftHandInput = false;
    }



    /*
     * Right B up
     */
    public void SetRightBButtonUp() {
        rightBDown = false;
        leftHandInput = false;
    }

    public bool GetRightBDown() {
        return rightBDown;
    }

    /*
     * Left Grip Down
     */
    public void SetLeftGripDown() {
        leftGripDown = true;
        leftHandInput = true;
    }

    /*
     * Left Grip Up
     */
    public void SetLeftGripUp() {
        leftGripDown = true;
        leftHandInput = true;
    }

    /*
     * Right Grip Down
     */
    public void SetRightGripDown() {
        rightGripDown = true;
        leftHandInput = false;
    }

    /*
     * Right Grip Up
     */
    public void SetRightGripUp() {
        rightGripDown = false;
        leftHandInput = false;
    }

    /*
     * Set right thumbstick analog x
     */
    public void SetRightThumbAnalogX(float x) {
        rightThumbAnalogX = x;
    }
    /*
     * Set right thumbstick analog y
     */
    public void SetRightThumbAnalogY(float y) {
        rightThumbAnalogY = y;
    }

    /*
     * Get right thumbstick analog x
     */
    public float GetRightThumbAnalogX() {
        return rightThumbAnalogX;
    }

    /*
     * Get right thumbstick analog y
     */
    public float GetRightThumbAnalogY() {
        return rightThumbAnalogY;
    }

    /*
    * Set left thumbstick analog x
    */
    public void SetLeftThumbAnalogX(float x) {
        leftThumbAnalogX = x;
    }
    /*
     * Set left thumbstick analog y
     */
    public void SetLeftThumbAnalogY(float y) {
        leftThumbAnalogY = y;
    }

    /*
     * Get left thumbstick analog x
     */
    public float GetLeftThumbAnalogX() {
        return leftThumbAnalogX;
    }

    /*
     * Get left thumbstick analog y
     */
    public float GetLeftThumbAnalogY() {
        return leftThumbAnalogY;
    }
}
