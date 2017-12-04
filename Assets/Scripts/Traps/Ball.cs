using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed = 12.0f;
    public float posXStart;
    public float posXEnd;
    public float posYLine1;
    public float posYLine2;
    public float posYLine3;

    private Vector3 direction;
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        // Elige si obliga al jugador a moverse
        int pos = 0;
        if (Random.Range(0.0f, 1.0f) <= GameSettings.KillingBoulderProb) {
            // Línea del Kiwi
            if (Kiwi.instance.transform.position.y == 0.545f) {
                pos = 0;
            } else if (Kiwi.instance.transform.position.y == -0.015f) {
                pos = 1;
            } else {
                pos = 2;
            }
        } else {
            // Posición aleatoria
            pos = Random.Range(0, 3);
        }
        // Elige la posición
        switch (pos) {
            case 0:
                transform.position = new Vector3(posXStart, posYLine1, 0);
                spriteRenderer.sortingOrder = 12;
                break;
            case 1:
                transform.position = new Vector3(posXStart, posYLine2, 0);
                spriteRenderer.sortingOrder = 13;
                break;
            case 2:
                transform.position = new Vector3(posXStart, posYLine3, 0);
                spriteRenderer.sortingOrder = 14;
                break;
        }
        // Dirección del movimiento
        direction = Vector3.left;
    }

    // Update is called once per frame
    void Update () {
        if (transform.position.x < posXEnd) {
            // Fuera de la pantalla
            gameObject.SetActive(false);
        } else {
            transform.position += (direction * speed * Time.deltaTime);
        }
    }
}
