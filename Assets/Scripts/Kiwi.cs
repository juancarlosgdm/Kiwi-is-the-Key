using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwi : MonoBehaviour {
    /* Singleton */
    public static Kiwi instance;

    private int currentKeyCode;
    private List<int> bannedKeys;

    private void Awake() {
        // Singleton
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(this);
        }
    }

    private void Start() {
        currentKeyCode = -1;
        bannedKeys = new List<int>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        KiwiIsDead(true);
    }

    public void KiwiIsDead(bool anim) {
        MenuManager.instance.GameOver();
    }

    public void MoveTo(int keyCode) {
        if ((keyCode != currentKeyCode) && (!bannedKeys.Contains(keyCode))) {
            if (currentKeyCode != -1) {
                if (Keyboard.instance.KiwiLeavesKey(currentKeyCode)) {
                    bannedKeys.Add(currentKeyCode);
                    StartCoroutine("FreeBannedKey", currentKeyCode);
                }
            }
            currentKeyCode = keyCode;
            Keyboard.instance.KiwiArrivesToKey(currentKeyCode);
            TrapManager.instance.ActivateTrap();
            transform.position = Keyboard.instance.GetKeyPosition(currentKeyCode);
            //GetComponent<RectTransform>().anchoredPosition = Keyboard.instance.GetKeyPosition(currentKeyCode).anchoredPosition;
        }
    }

    private IEnumerator FreeBannedKey(int keyCode) {
        yield return new WaitForSeconds(GameSettings.KeyboardCD);
        bannedKeys.Remove(keyCode);
        Keyboard.instance.FreeBannedKey(keyCode);
    }

}
