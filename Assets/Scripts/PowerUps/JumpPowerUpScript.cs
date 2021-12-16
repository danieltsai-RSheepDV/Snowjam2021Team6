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
            // Done with object
            Destroy(this.gameObject);
        }
    }
}
