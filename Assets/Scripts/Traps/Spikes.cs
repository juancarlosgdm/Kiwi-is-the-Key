using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
    public float spikesLifetime = 3.0f;

    private void OnEnable() {
        // Elige posición en la que aparece
        //GetComponent<RectTransform>().anchoredPosition = Keyboard.instance.keysSprites[Random.Range(0, Keyboard.instance.keysSprites.Count)].rectTransform.anchoredPosition;
        // Lanza animación
        // Prepara su desactivación
        Invoke("DeactivateSpikes", spikesLifetime);
    }

    private void DeactivateSpikes() {
        gameObject.SetActive(false);
    }
}
