using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour {

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
        ChangeAnimatorSpeed();
    }

    private void ChangeAnimatorSpeed() {
        animator.speed = Random.Range(0.75f, 1.1f);
        Invoke("ChangeAnimatorSpeed", 2.0f);
    }
}
