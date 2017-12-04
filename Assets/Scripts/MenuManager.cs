using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    /* Singleton */
    public static MenuManager instance;

    public GameObject startMenu;
    public GameObject tutorialMenu;
    public GameObject gameoverMenu;
    [Space]
    public float tutorialTime = 2.0f;

    [HideInInspector]
    public bool inGame = false;

    private float gameoverTime;

    private void Awake() {
        // Singleton
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(this);
        }
    }

    public void GameOver() {
        inGame = false;
        gameoverTime = 0.0f;
        Invoke("UpdateGameoverTime", 1.5f);
        gameoverMenu.SetActive(true);
        AudioManager.instance.PlayGameOverMusic();
        TimeCounter.instance.ShowTimeWithSpritesGameover();
    }

    public void KeyPressed() {
        if (startMenu.activeSelf) {
            startMenu.SetActive(false);
            tutorialMenu.SetActive(true);
            Invoke("StartGame", tutorialTime);
        } else if (tutorialMenu.activeSelf) {
            StartGame();
        } else if (gameoverTime > 0.0f) {
            SceneManager.LoadScene(0);
        }
    }

    private void StartGame() {
        if (!inGame) {
            inGame = true;
            tutorialMenu.SetActive(false);
            AudioManager.instance.StopMenuMusic();
            TrapManager.instance.GameStarted();
            TimeCounter.instance.GameStarted();
        }
    }

    private void UpdateGameoverTime() {
        gameoverTime = 1.5f;
    }
}
