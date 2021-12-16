using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUpScript : MonoBehaviour
{
    private Rigidbody rb;

    // Touch = collect
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            // Modify game state, usually the player ->
            rb = other.GetComponentInParent<Rigidbody>();
            rb.AddForce(transform.up * 1000);
            // Done with object
            Destroy(this.gameObject);
        }
    }
}
