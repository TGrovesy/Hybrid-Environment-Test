using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabablePaper : OVRGrabbable {

    public bool collected = false;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
    }


    // Update is called once per frame
    public void Update() {
        if (isGrabbed) {
            float yScale = transform.localScale.y;
            if (transform.GetComponentInParent<GestureGrab>() != null) {
                if (transform.GetComponentInParent<GestureGrab>().isLeft) {
                    transform.localPosition = new Vector3(0.08f, yScale / 2, 0.0f);
                } else {
                    transform.localPosition = new Vector3(-0.08f, -yScale / 2, 0.0f);
                }
            } 
        }
    }
}
