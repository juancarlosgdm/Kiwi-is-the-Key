using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed = 12.0f;

    private Vector3 direction;

    private void OnEnable() {
        // Elige posición en la que aparece
        // Dirección del movimiento
        direction = Vector3.left;
    }

    // Update is called once per frame
    void Update () {
		GetComponent<RectTransform>().position += (direction * speed * Time.deltaTime);
	}
}
