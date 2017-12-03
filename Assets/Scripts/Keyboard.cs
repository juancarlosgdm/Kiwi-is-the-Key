using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour {
    /* Singleton */
    public static Keyboard instance;

    public List<Image> keysSprites;

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
        keysSprites[keyCode].color = Color.white;
    }

    public RectTransform GetKeyPosition(int keyCode) {
        return keysSprites[keyCode].GetComponent<RectTransform>();
    }

    public bool KiwiLeavesKey(int keyCode) {
        bool res = true;
        keysSprites[keyCode].color = Color.gray;
        if (++keysSteps[keyCode] == GameSettings.LimitKeyboardSteps) {
            keysSprites[keyCode].color = Color.black;
            res = false;
        }
        //Debug.Log(keysSteps[keyCode]);

        return res;
    }

    public void KiwiArrivesToKey(int keyCode) {
        if (keysSprites[keyCode].color == Color.black) {
            Debug.Log("Dead :S");
        } else {
            keysSprites[keyCode].color = Color.green;
            AudioManager.instance.PlayKeySound(KeysInputManager.instance.GetKeyCode(keyCode - 1));
        }
    }

}
