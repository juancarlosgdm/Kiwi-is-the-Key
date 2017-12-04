using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwi : MonoBehaviour {
    /* Singleton */
    public static Kiwi instance;

    private int currentKeyCode;
    private List<int> bannedKeys;
    private bool dead;

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
        dead = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!dead) {
            KiwiIsDead(false);
        }
    }

    public void KiwiIsDead(bool anim) {
        dead = true;
        MenuManager.instance.GameOver();
        if (anim) {
            GetComponent<Animator>().SetTrigger("Fall");
        } else {
            GetComponent<Animator>().SetTrigger("Dead");
        }
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
            // Activa una trampa, si procede
            if (Random.Range(0.0f, 1.0f) <= GameSettings.TrapActionProb) {
                TrapManager.instance.ActivateTrap();
            }
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
