using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class ControllerInput : MonoBehaviour
{


    public bool inputEnabled = true;

    private List<UnityEngine.XR.InputDevice> inputDevices;

    public GameObject inputManagerObj;
    public InputManager inputManager;

    // Start is called before the first frame update
    void Start() {
        inputManager = inputManagerObj.GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {

        UpdateInput();//Update input devices
    }

    private void UpdateInput()
    {

        //Listen for devices
        var leftHandedControllers = new List<UnityEngine.XR.InputDevice>();
        var desiredCharacteristicsLeft = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Left | UnityEngine.XR.InputDeviceCharacteristics.Controller;
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristicsLeft, leftHandedControllers);


        var rightHandedControllers = new List<UnityEngine.XR.InputDevice>();
        var desiredCharacteristicsRight = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Right | UnityEngine.XR.InputDeviceCharacteristics.Controller;
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristicsRight, rightHandedControllers);

        if (inputEnabled) {
            if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger)) Debug.Log("r trigger");
            foreach (var device in leftHandedControllers) {
                bool triggerValue = false;
                if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue) {
                    inputManager.SetLeftTriggerDown();
                } else if(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && !triggerValue) {
                    inputManager.SetLeftTriggerUp();
                }


                bool gripValue = false;
                if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out gripValue) && gripValue) {
                    inputManager.SetLeftGripDown();
                } else if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out gripValue) && !gripValue) {
                    inputManager.SetLeftGripUp();
                }

                bool aValue = false;
                if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out aValue) && aValue) {
                    inputManager.SetLeftAButtonDown();
                } else if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out aValue) && !aValue) {
                    inputManager.SetLeftAButtonUp();
                }

                bool bValue = false;
                if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out bValue) && bValue) {
                    inputManager.SetLeftBButtonDown();
                } else if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out bValue) && !bValue) {
                    inputManager.SetLeftBButtonUp();
                }
            }

            foreach (var device in rightHandedControllers) {
                bool triggerValue = false;
                if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue) {
                    inputManager.SetRightTriggerDown();
                } else if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && !triggerValue) {
                    inputManager.SetRightTriggerUp();
                }


                bool gripValue = false;
                if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out gripValue) && gripValue) {
                    inputManager.SetRightGripDown();
                } else if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out gripValue) && !gripValue) {
                    inputManager.SetRightGripUp();
                }

                bool aValue = false;
                if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out aValue) && aValue) {
                    inputManager.SetRightAButtonDown();
                } else if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out aValue) && !aValue) {
                    inputManager.SetRightAButtonUp();
                }

                bool bValue = false;
                if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out bValue) && bValue) {
                    inputManager.SetRightBButtonDown();
                } else if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out bValue) && !bValue) {
                    inputManager.SetRightBButtonUp();
                }
            }
        }
    }
}
