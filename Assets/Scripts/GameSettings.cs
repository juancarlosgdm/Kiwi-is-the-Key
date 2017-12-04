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
    public float trapFrequencySeconds = 1.0f;

    [Header("Key Traps Settings")]
    public int spikesProbKey = 1;
    public int boulderProbKey = 1;
    [Range(0.0f, 1.0f)]
    public float trapActionProb = 0.2f;

    [Header("Other Traps Settings")]
    [Range(0.0f, 1.0f)]
    public float killingBoulderProb = 0.2f;

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
            return instance.trapFrequencySeconds;
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

    public static float TrapActionProb {
        get {
            return instance.trapActionProb;
        }
    }

    /* Other Traps Settings */

    public static float KillingBoulderProb {
        get {
            return instance.killingBoulderProb;
        }
    }

}
