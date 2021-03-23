using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableCube : OVRGrabbable
{

    private float distanceThreashold = 0.1f;
    public float tableHeight;

    public CubeStacker cubeStacker;
    public bool isStacked = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        cubeStacker = transform.parent.GetComponent<CubeStacker>();
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

    public void CheckNearCube() {
        GameObject closetCube = null;
        float closetDistance = float.MaxValue;
        //Get closest cube
        for(int i = 0; i < cubeStacker.GetCubes().Count; i++) {
            GameObject cube = cubeStacker.GetCubes()[i];
            if (cube.Equals(gameObject)) continue;
            float distance = Vector3.Distance(cube.transform.position, transform.position);
           // Debug.LogError("i: " + distance);
            if (distance < closetDistance) {
                closetDistance = distance;
                closetCube = cube.gameObject;
            }
        }


        float distanceToAttach = Vector3.Distance(closetCube.transform.position, transform.position);
        float yScale = transform.localScale.y;

        if (distanceToAttach <= distanceThreashold) {
            Vector3 attach = closetCube.transform.GetChild(0).transform.position;
            Vector3 newPos = new Vector3(attach.x, attach.y + (yScale /2), attach.z);
            Quaternion newRot = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
            gameObject.transform.SetPositionAndRotation(newPos, newRot);
            gameObject.transform.SetParent(closetCube.transform);

            isStacked = true;
        } else {//attach to table
            Vector3 attach = transform.position;
            attach.y = tableHeight;
            //attach.y += yScale / 2;
            Quaternion newRot = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
            transform.SetPositionAndRotation(attach, newRot);
            isStacked = false;
        }
    }

}
