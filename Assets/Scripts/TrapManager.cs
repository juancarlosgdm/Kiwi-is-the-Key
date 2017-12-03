using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour {
    public static TrapManager instance;

    public GameObject ball;
    public GameObject spikes;

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
        spikes.SetActive(true);
    }

    private void ActivateBall() {
        ball.SetActive(true);
    }
}
