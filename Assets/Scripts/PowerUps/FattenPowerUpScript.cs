using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FattenPowerUpScript : MonoBehaviour
{

    // Touch = collect
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            // Modify game state, usually the player ->
            other.GetComponentInParent<PlayerController>().AddRadius(5f);
            // Done with object
            Destroy(this.gameObject);
        }
    }
}
