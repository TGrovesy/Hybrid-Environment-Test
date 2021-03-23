using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandButton : MonoBehaviour
{

    public UnityEvent eventToInvoke;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "HandCollider") {//Bad practise i know shall change to object instance 
            eventToInvoke?.Invoke();
        }
    }
}
