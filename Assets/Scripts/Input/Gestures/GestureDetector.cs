using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

// struct = class without functions
[System.Serializable]
public struct Gesture {
    public string name;
    public List<Vector3> fingerDatas;
    public UnityEvent onRecognized;
}

public class GestureDetector : MonoBehaviour {
    [Header("Threshold")]
    public float threshold = 0.1f;

    [Header("Hand Skeleton")]
    public OVRSkeleton skeleton;

    // List of gestures
    [Header("List of Gestures")]
    public List<Gesture> gestures;
    private Gesture previousGesture;

    // List of bones took from the OVRSkeleton
    private List<OVRBone> fingerbones = null;

    [Header("DebugMode")]
    public bool debugMode = true;

    // Other boolean to check if are working correctly
    private bool hasStarted = false;
    private bool hasRecognize = false;
    private bool done = false;

    // Add an event if you want to make happen when a gesture is not identified
    [Header("Not Recognized Event")]
    public UnityEvent notRecognize;

    void Start() {
        // When the Oculus hand had his time to initialize hand, with a simple coroutine i start a delay of
        // a function to initialize the script
        StartCoroutine(DelayRoutine(2.5f, Initialize));
    }

    // Coroutine used for delay some function
    public IEnumerator DelayRoutine(float delay, Action actionToDo) {
        yield return new WaitForSeconds(delay);
        actionToDo.Invoke();
    }

    public void Initialize() {
        // Check the function for know what it does
        SetSkeleton();

        // After initialize the skeleton set a boolean to true to confirm the initialization
        hasStarted = true;
    }
    public void SetSkeleton() {
        // Populate the private list of fingerbones from the current hand we put in the skeleton
        fingerbones = new List<OVRBone>(skeleton.Bones);
    }

    void Update() {
        //Debug Mode allows saving with spacebar
        if (debugMode && Input.GetKeyDown(KeyCode.Space)) {
            Save();
        }

        
        //if the initialization was successful
        if (hasStarted.Equals(true)) {
            // start to Recognize every gesture we make
            Gesture currentGesture = Recognize();

            hasRecognize = !currentGesture.Equals(new Gesture());

            // and if the gesture is recognized
            if (hasRecognize) {
                //already recognised avoids loop
                done = true;
                if (!currentGesture.Equals(previousGesture)) {
                    // after that i will invoke what put in the Event if is present
                    currentGesture.onRecognized?.Invoke();
                }
            }else {
                //signal finished
                if (done) {
                    Debug.Log("Not Recognized");
                    done = false;
                    //Invoke unrecognised event
                    notRecognize?.Invoke();
                }
            }
            previousGesture = currentGesture;
        }
    }

    void Save() {
        Gesture g = new Gesture();
        g.name = "New Gesture";

        List<Vector3> data = new List<Vector3>();

       //Gather postion of finger bones
        foreach (var bone in fingerbones) {
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }

        g.fingerDatas = data;
        
        gestures.Add(g);//Add/Save Gesture
    }

    Gesture Recognize() {
        try {
            Gesture currentGesture = new Gesture();

            //closest distance
            float currentMin = Mathf.Infinity;

            //Cycle through gestures
            for (int g = 0; g < gestures.Count; g++) {
                float sumDistance = 0;

                bool isDiscarded = false;

                //Get skellington transofrms
                for (int i = 0; i < fingerbones.Count; i++) {
                    //Position of current finger bone
                    Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerbones[i].Transform.position);

                    //compare finger bone to finger bone in gesture being checked
                    float distance = Vector3.Distance(currentData, gestures[g].fingerDatas[i]);

                    //if our distnace is greater then discard
                    if (distance > threshold) {
                        isDiscarded = true;
                        break;
                    }

                    //increase sum of distnace if not discarded
                    sumDistance += distance;
                }

                //if the gesture checked is not discarded and closer than the current closest pose then we set this to be the new closer pose
                if (!isDiscarded && sumDistance < currentMin) {
                    currentMin = sumDistance;
                    currentGesture = gestures[g];
                }
            }
           
            return currentGesture;
        }catch(ArgumentOutOfRangeException e) {
            return gestures[gestures.Count-1];
        }
    }
}
