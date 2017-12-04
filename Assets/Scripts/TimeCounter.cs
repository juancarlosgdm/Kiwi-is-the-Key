using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour {
    /* Singleton */
    public static TimeCounter instance;

    public List<SpriteRenderer> ingamePositionSprites;
    public List<Sprite> numberSprites;

    private float time;

    private void Awake() {
        // Singleton
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(this);
        }
    }

    public void GameStarted() {
        time = 0.0f;
        InvokeRepeating("UpdateTime", 1.0f, 1.0f);
    }

    private void UpdateTime() {
        time += 1.0f;
        ShowTimeWithSpritesInGame();
    }

    private void ShowTimeWithSpritesInGame() {
        // Minutos (decenas)
        ingamePositionSprites[0].sprite = numberSprites[Mathf.FloorToInt(time / 60) / 10];
        // Minutos (unidades)
        ingamePositionSprites[1].sprite = numberSprites[Mathf.FloorToInt(time / 60) % 10];
        // Segundos (decenas)
        ingamePositionSprites[2].sprite = numberSprites[Mathf.FloorToInt(time % 60) / 10];
        // Segundos (unidades)
        ingamePositionSprites[3].sprite = numberSprites[Mathf.FloorToInt(time % 60) % 10];
    }
}
