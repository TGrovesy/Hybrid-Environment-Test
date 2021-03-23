using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTracker : MonoBehaviour {

    public bool testStarted = false;
    private bool testFinished = false;

    public bool paperTaskComplete = false, cubeTaskComplete = false, moleTaskComplete = false;

    public PaperCollector paperCollector;
    public SpawnArea moleSpawner;
    public CubeStacker cubeStacker;

    public GameObject instructionsObj;
    public List<GameObject> instructions;


    // Start is called before the first frame update
    void Start() {
        for(int i = 0; i < instructionsObj.transform.childCount; i++) {
            instructions.Add(instructionsObj.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        if (!testStarted) {
            if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger)) {//Start welcome
                testStarted = true;
                WelcomeInstructions();
            }
        }else{
            if (!cubeTaskComplete) {
                CubeTracker();
            }else if (!moleTaskComplete) {
                MoleTracker();
            }else if (!paperTaskComplete) {
                PaperTracker();
            } 

            if(paperTaskComplete && cubeTaskComplete && moleTaskComplete && !testFinished) {
                GetAudio("Goodbye").Play();
                testFinished = true;
            }
        }
    }

    private void WelcomeInstructions() {
        AudioSource welcome = GetAudio("Welcome");
        AudioSource taskOverview = GetAudio("TaskOverview");
        AudioSource cubeInstructions = GetAudio("CubeTask");
        welcome.Play();
        taskOverview.PlayDelayed(5);
        cubeInstructions.PlayDelayed(15);
    }


    private void CubeTracker() {
        if (cubeStacker.IsTaskComplete()) {
            cubeTaskComplete = true;
            MoleInstructions();
        }
    }

    private void MoleInstructions() {
        GetAudio("MoleTask").Play();
    }

    private void MoleTracker() {
        if (moleSpawner.IsTaskComplete()) {
            moleTaskComplete = true;
            PaperInstructions();
        }
    }

    private void PaperInstructions() {
        GetAudio("PaperTask").Play();
    }

    private void PaperTracker() {
        if (paperCollector.IsTaskComplete()) {
            paperTaskComplete = true;
        }
    }



    private AudioSource GetAudio(string audioName) {
        for(int i = 0; i < instructions.Count; i++) {
            if (instructions[i].name.Equals(audioName)) {
                return instructions[i].GetComponent<AudioSource>();
            }
        }
        return null;//Could not find source
    }

}
