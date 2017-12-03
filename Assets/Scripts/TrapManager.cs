using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour {
    public static TrapManager instance;

    public GameObject ball;
    public GameObject spikes;

    public List<GameObject> ballsPool;
    public List<GameObject> spikesList;

    private void Awake() {
        // Singleton
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(this);
        }
    }

    public void ActivateTrap() {
        int t = Random.Range(0, 2);
        if (t == 0) {
            Debug.Log("pinchos");
            // Pinchos
            ActivateSpikes();
        } else {
            Debug.Log("bola");
            // Bola que persigue
            ActivateBall();
        }
    }

    private void ActivateSpikes() {
        int maxTries = 10;
        int i = Random.Range(0, spikesList.Count);
        while ((spikesList[i].activeSelf) && (maxTries > 0)) {
            i = Random.Range(0, spikesList.Count);
            --maxTries;
        }
        if (!spikesList[i].activeSelf) {
            spikesList[i].SetActive(true);
        }
    }

    private void ActivateBall() {
        int i = 0;
        while ((i < ballsPool.Count) && (ballsPool[i].activeSelf)) {
            ++i;
        }
        if (i == ballsPool.Count) {
            ballsPool.Add(GameObject.Instantiate(ball));
        }
        ballsPool[i].SetActive(true);
    }
}
