using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {
    /* Singleton */
    public static GameSettings instance;
    
    [Header("Configuration")]
    public float keyboardCD = 2.0f;
    public int limitKeyboardSteps = 3;

    [Header("Random Traps Settings")]
    public int spikesProbRandom = 1;
    public int boulderProbRandom = 1;
    public float trapFrequency = 1.0f;

    [Header("Key Traps Settings")]
    public int spikesProbKey = 1;
    public int boulderProbKey = 1;

    private void Awake() {
        // Singleton
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(this);
        }
    }

    /* Configuration */

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

    /* Random Traps Settings */

    public static int SpikesProbRandom {
        get {
            return instance.spikesProbRandom;
        }
    }

    public static int BoulderProbRandom {
        get {
            return instance.boulderProbRandom;
        }
    }

    public static float TrapFrequency {
        get {
            return instance.trapFrequency;
        }
    }

    /* Key Traps Settings */

    public static int SpikesProbKey {
        get {
            return instance.spikesProbKey;
        }
    }

    public static int BoulderProbKey {
        get {
            return instance.boulderProbKey;
        }
    }

}
