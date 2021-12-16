using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    // Touch = collect
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            // Modify game state, usually the player ->

            // Done with object
            Destroy(this.gameObject);
        }
    }
}
