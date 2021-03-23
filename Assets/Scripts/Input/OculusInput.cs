using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusInput : MonoBehaviour
{

    public GameObject head;
    public GameObject tracked;
    public GameObject room;
    public GameObject forward;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger)) {
            Debug.Log("fuck");
            Vector3 p = GetComponent<OVRManager>().transform.position;
            Vector3 hp = head.transform.localPosition;
            transform.SetPositionAndRotation(new Vector3(tracked.transform.position.x + hp.x, 0, tracked.transform.position.y + hp.y), Quaternion.identity);
            //GetComponent<OVRManager>().transform.LookAt(new Vector3(0, forward.transform.position.y, 0));
        }
    }
}
