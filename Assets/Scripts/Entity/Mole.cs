using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{

    private float timeAlive = 0.0f;
    private bool whacked = false;

    float popDistance;
    float popDelay = 0.025f;

    private bool isLiving = false;


    // Start is called before the first frame update
    void Start()
    {
        popDistance = transform.localScale.y;
        StartCoroutine(PopUp(50));
    }

    // Update is called once per frame
    void Update()
    {
        if (isLiving) {
            //INCREMENT Time Alive
            timeAlive += Time.deltaTime;
        }
    }

    public float GetTimeAlive() {
        return timeAlive;
    }

    private void OnTriggerEnter(Collider other) {
        //Debug.LogError("Whack!, " + other.gameObject.tag);
        if (other.gameObject.tag == "HandCollider") {//Bad practise i know shall change to object instance
            whacked = true;
            AudioSource.PlayClipAtPoint(GetComponentInParent<SpawnArea>().GetDeathSound(), transform.position);
        }
    }

    private void OnCollisionStay(Collision other) {
        //Debug.LogError("Whack!, " + other.gameObject.tag);
        if (other.gameObject.tag == "HandCollider") {//Bad practise i know shall change to object instance
            whacked = true;
            AudioSource.PlayClipAtPoint(GetComponentInParent<SpawnArea>().GetDeathSound(), transform.position);
        }
    }

    private void OnCollisionExit(Collision other) {
        //Debug.LogError("Whack!, " + other.gameObject.tag);
        if (other.gameObject.tag == "HandCollider") {//Bad practise i know shall change to object instance
            whacked = true;
            AudioSource.PlayClipAtPoint(GetComponentInParent<SpawnArea>().GetDeathSound(), transform.position);
        }
    }

    public bool IsWhacked() {
        return whacked;
    }

    public IEnumerator PopUp(int interpulations) {
        Vector3 newPos = transform.position;
        AudioSource.PlayClipAtPoint(GetComponentInParent<SpawnArea>().GetSpawnSound(), transform.position);
        for (int i = 0; i < interpulations; i++) {
            newPos.y += popDistance / interpulations;
            transform.position = newPos;
            yield return new WaitForSeconds(popDelay / interpulations);
        }
        isLiving = true;
    }

    public IEnumerator PopDown(int interpulations) {
        Vector3 newPos = transform.position;
        isLiving = false;
        for (int i = 0; i < interpulations; i++) {
            newPos.y -= popDistance / interpulations;
            transform.position = newPos;
            yield return new WaitForSeconds(popDelay / interpulations);
        }
        Destroy(gameObject);
    }

    public bool IsLiving() {
        return isLiving;
    }
}
