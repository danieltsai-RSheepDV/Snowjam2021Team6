using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FattenPowerUpScript : MonoBehaviour
{

    // Touch = collect
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            // Modify game state, usually the player ->
            other.GetComponentInParent<PlayerController>().growthRate *= 100.5f;
            // Done with object
            Destroy(this.gameObject);
        }
    }
}
