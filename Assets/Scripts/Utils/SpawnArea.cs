using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour {

    public GameObject spawnedObj;
    private int currentNumOfMoles = 0;
    public int maxMoles = 3;
    public int currentScore = 0;
    public int winningScore = 5;
    public float moleTTL = 5.0f;



    //Sounds
    public AudioClip moleSpawnSound;
    public AudioClip moleDeathSound;

    private List<GameObject> aliveObjects;

    private bool taskComplete = false;

    public bool gameRunning = false;


    // Start is called before the first frame update
    void Start() {
        aliveObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update() {
        if (gameRunning) {
            //Check Number of moles
            if (currentNumOfMoles < maxMoles) {
                SpawnMole();
            }
            CheckTimeToLive();


            CheckScore();
            //Check for Win
            if (currentScore >= winningScore) {
                taskComplete = true;
                KillAllMoles();//delete all moles
                gameRunning = false;//end game
            }
        }
    }

    public void SetRunning(bool value) {
        if (value != gameRunning) {//ensures no double trigger
            gameRunning = value;
            if (gameRunning) {
                currentScore = 0;
            }
        }
    }

    private void CheckScore() {
        for (int i = 0; i < aliveObjects.Count; i++) {
            if (aliveObjects[i] != null) {
                if (aliveObjects[i].GetComponent<Mole>().IsWhacked()) {
                    currentScore++;
                    //Kill Mole
                    Destroy(aliveObjects[i]);
                    currentNumOfMoles--;
                }
            }
        }
    }

    private void CheckTimeToLive() {
        for (int i = 0; i < aliveObjects.Count; i++) {
            if (aliveObjects[i] != null) {
                if (aliveObjects[i].GetComponent<Mole>().GetTimeAlive() >= moleTTL && aliveObjects[i].GetComponent<Mole>().IsLiving()) {
                    //Kill Mole
                    StartCoroutine(aliveObjects[i].GetComponent<Mole>().PopDown(50));
                    currentNumOfMoles--;
                }
            }
        }
    }

    private void KillAllMoles() {
        for (int i = 0; i < aliveObjects.Count; i++) {
            if (aliveObjects[i] != null) {
                //Kill Mole
                Destroy(aliveObjects[i]);
                currentNumOfMoles--;
            }
        }
    }

    private void SpawnMole() {
        Vector3 origin;
        Vector3 range;
        Vector3 randomRange;
        Vector3 randomCoordinate;
        origin = transform.position;
        range = transform.localScale / 2.0f;
        randomRange = new Vector3(Random.Range(-range.x, range.x),
                                          -range.y - (spawnedObj.transform.localScale.y / 2),
                                           Random.Range(-range.z, range.z));
        randomCoordinate = origin + randomRange;
        
        //check if vector is near another mole
        for (int i = 0; i < aliveObjects.Count; i++) {
            if (aliveObjects[i] != null) {
                Vector3 molePos = aliveObjects[i].transform.position;
                if (Vector3.Distance(molePos, randomCoordinate) > 0.05f) {
                    randomCoordinate.x += .15f;
                    break;
                }
            }
        }
        //spawn object
        currentNumOfMoles++;
        aliveObjects.Add(Instantiate(spawnedObj, randomCoordinate, Quaternion.identity));
        aliveObjects[aliveObjects.Count - 1].transform.parent = transform;
    }

    public Color GizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);

    void OnDrawGizmos() {
        Gizmos.color = GizmosColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    public bool IsTaskComplete() {
        return taskComplete;
    }

    public AudioClip GetSpawnSound() {
        return moleSpawnSound;
    }
    public AudioClip GetDeathSound() {
        return moleDeathSound;
    }
}
