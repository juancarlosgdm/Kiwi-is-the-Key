using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysInputManager : MonoBehaviour {
    /* Singleton */
    public static KeysInputManager instance;

    public KeysInputConfiguration keysConfig;

    private int code;

    private void Awake() {
        // Singleton
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(this);
        }
        keysConfig = GetComponent<KeysInputConfiguration>();
    }

    // Use this for initialization
    private void Start () {
        code = -1;
	}
	
	// Update is called once per frame
	private void Update () {
        int i = 0;
        code = -1;
        while (i < keysConfig.keyboardSize) {
            if (Input.GetKeyDown(keysConfig.keysConfiguration[i].key)) {
                code = keysConfig.keysConfiguration[i].code;
                i = keysConfig.keyboardSize;
            } else {
                ++i;
            }
        }
        if (code != -1) {
            Kiwi.instance.MoveTo(code);
        }
	}

    public KeyCode GetKeyCode(int code) {
        return keysConfig.keysConfiguration[code].key;
    }
}
