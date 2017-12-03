using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {
    /* Singleton */
    public static GameSettings instance;
    
    public float keyboardCD = 2.0f;
    public int limitKeyboardSteps = 3;

    [Header("Traps Settings")]
    public int spikesProb = 1;
    public int boulderProb = 1;

    private void Awake() {
        // Singleton
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(this);
        }
    }

    public static float KeyboardCD {
        get {
            return instance.keyboardCD;
        }
    }

    public static int LimitKeyboardSteps {
        get {
            return instance.limitKeyboardSteps;
        }
    }
	
}
