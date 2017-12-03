using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
    public float spikesLifetime = 3.0f;

    private Animator animator;
    private BoxCollider2D boxCollider;

    private void Awake() {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnEnable() {
        // Delay hasta que los pinchos matan
        Invoke("StartKilling", 1.0f);
        // Delay hasta que los pinchos bajan
        Invoke("EndAnimation", spikesLifetime - 1.0f);
        // Delay hasta que se desactiva la trampa
        Invoke("DeactivateSpikes", spikesLifetime);
    }

    private void DeactivateSpikes() {
        gameObject.SetActive(false);
    }

    private void EndAnimation() {
        animator.SetTrigger("SpikesAnimEnd");
        boxCollider.enabled = false;
    }

    private void StartKilling() {
        boxCollider.enabled = true;
    }
}
