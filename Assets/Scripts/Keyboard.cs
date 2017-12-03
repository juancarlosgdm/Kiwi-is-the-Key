using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour {
    /* Singleton */
    public static Keyboard instance;

    public List<SpriteRenderer> keysSprites;
    public List<SpriteRenderer> pressedKeysSprites;

    private List<int> keysSteps;

    private void Awake() {
        // Singleton
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(this);
        }
    }

    private void Start() {
        keysSteps = new List<int>();
        for (int i=0 ; i<keysSprites.Count ; i++) {
            keysSteps.Add(0);
        }
    }

    public void FreeBannedKey(int keyCode) {
        keysSprites[keyCode].transform.GetChild(0).gameObject.SetActive(false);
    }

    public Vector3 GetKeyPosition(int keyCode) {
        return keysSprites[keyCode].transform.position;
    }

    public bool KiwiLeavesKey(int keyCode) {
        bool res = true;
        //keysSprites[keyCode].color = Color.gray;
        if (++keysSteps[keyCode] == GameSettings.LimitKeyboardSteps) {
            keysSprites[keyCode].transform.GetChild(0).gameObject.SetActive(false);
            keysSprites[keyCode].transform.GetChild(GameSettings.LimitKeyboardSteps).gameObject.SetActive(true);
            res = false;
        } else {
            keysSprites[keyCode].transform.GetChild(keysSteps[keyCode]).gameObject.SetActive(true);
            keysSprites[keyCode].transform.GetChild(0).GetChild(keysSteps[keyCode]-1).gameObject.SetActive(true);
        }
        //Debug.Log(keysSteps[keyCode]);

        return res;
    }

    public void KiwiArrivesToKey(int keyCode) {
        if (keysSprites[keyCode].color == Color.black) {
            Debug.Log("Dead :S");
        } else {
            keysSprites[keyCode].transform.GetChild(0).gameObject.SetActive(true);
            AudioManager.instance.PlayKeySound(KeysInputManager.instance.GetKeyCode(keyCode - 1));
        }
    }

}
