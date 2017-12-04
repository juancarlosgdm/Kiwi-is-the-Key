using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    /* Singleton */
    public static MenuManager instance;

    public GameObject startMenu;
    public GameObject gameoverMenu;

    [HideInInspector]
    public bool inGame = false;

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
        gameoverMenu.SetActive(true);
        AudioManager.instance.PlayGameOverMusic();
    }

    public void KeyPressed() {
        if (startMenu.activeSelf) {
            inGame = true;
            startMenu.SetActive(false);
            AudioManager.instance.StopMenuMusic();
        } else {
            SceneManager.LoadScene(0);
        }
    }
}
