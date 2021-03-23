using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStacker : MonoBehaviour
{

    public List<GameObject> cubes;
    public int stackCount = 0;

    public bool taskComplete = false;
    public int stackTarget = 3;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++) {
            cubes.Add(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!taskComplete) {
            stackCount = 0;
            for (int i = 0; i < cubes.Count; i++) {//Inefficent way to check task I know plz dont kill me
                if (cubes[i].GetComponent<GrabableCube>().isStacked) {
                    stackCount++;
                } 
            }

            if (stackCount >= stackTarget) { //The cube on bottom is never stacked
                taskComplete = true;
            }
        }

    }

    public List<GameObject> GetCubes() {
        return cubes;
    }

    public bool IsTaskComplete() {
        return taskComplete;
    }
}
