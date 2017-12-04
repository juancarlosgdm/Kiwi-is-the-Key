using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionAdjuster : MonoBehaviour {

    private void Awake() {
        // Se ajusta el tamaño de cámara a la resolución
        float cameraSize;
        if (Mathf.Approximately(Screen.width / Screen.height, 16 / 9)) {
            cameraSize = 1.975f * 1472 / Screen.width;
        } else {
            cameraSize = 2.6f * 1024 / Screen.width;
        }
        GetComponent<Camera>().orthographicSize = cameraSize;
    }
}
