using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUpScript : MonoBehaviour
{
    
    [SerializeField] private float jumpVelocity = 20;
    private Rigidbody rb;

    // Touch = collect
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            // Modify game state, usually the player ->
            rb = other.GetComponentInParent<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
            if (rb.velocity.x < 1f && rb.velocity.z < 1f) {
                rb.velocity = new Vector3(1, jumpVelocity, rb.velocity.z);
            }
            // Decision to keep as permanent object
            // Destroy(this.gameObject);

        }
    }
}
