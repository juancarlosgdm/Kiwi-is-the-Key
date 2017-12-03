using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyConfiguration {
    public KeyCode key;
    public int code;
}

public class KeysInputConfiguration : MonoBehaviour {
    public List<KeyConfiguration> keysConfiguration;
    
    public int keyboardSize {
        get {
            return keysConfiguration.Count;
        }
    }
	
}
