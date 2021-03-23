using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using Oculus;

public class HandTrackingGrabber : OVRGrabber
{

    private OVRHand hand;

    public float pinchThreashold = 0.7f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hand = GetComponent<OVRHand>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        CheckIndexPinch();
    }

    void CheckIndexPinch() {
        float pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);

        bool isPinching = pinchStrength > pinchThreashold;

        if(!m_grabbedObj && isPinching && m_grabCandidates.Count > 0) {
            GrabBegin();
            Debug.LogError("FUCK YOU!");
        }else if(m_grabbedObj && !isPinching) {
            GrabEnd();
            Debug.LogError("FUCK YOU End!");
        }
    }
}
