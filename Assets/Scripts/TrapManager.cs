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

    public void GameStarted() {
        InvokeRepeating("ActivateTrap", GameSettings.TrapFrequency, GameSettings.TrapFrequency);
    }

    public void ActivateTrap() {
        int t = Random.Range(0, GameSettings.BoulderProbKey + GameSettings.SpikesProbKey);
        if (t < GameSettings.SpikesProbKey) {
            // Pinchos
            ActivateSpikes();
        } else {
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
            // Aviso al kiwi
            Kiwi.instance.CalculateAlert(spikesList[i].transform.position);
            // Activación de los pinchos
            StartCoroutine("StartSpikes", spikesList[i]);
        }
    }

    private IEnumerator StartSpikes(GameObject spikes) {
        yield return new WaitForSeconds(1.5f);
        if (!spikes.activeSelf) {
            spikes.SetActive(true);
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
