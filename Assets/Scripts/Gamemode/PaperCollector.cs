using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCollector : MonoBehaviour
{

    public int collectedPaper = 0;
    public bool taskComplete = false;

    //public GameObject explosionEffect;
    public int amountToWin = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(collectedPaper >= amountToWin && !taskComplete) {
            
            //GameObject effect = Instantiate(explosionEffect, gameObject.transform.parent);
            //effect.transform.localPosition = Vector3.zero;
            taskComplete = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<GrabablePaper>() != null) {//object is paper
            Debug.LogError(other.gameObject.name);
            if (!other.gameObject.GetComponent<GrabablePaper>().collected) {
                other.gameObject.GetComponent<GrabablePaper>().collected = true;
                collectedPaper++;
            }
        }
    }

    public bool IsTaskComplete() {
        return taskComplete;
    }
}
