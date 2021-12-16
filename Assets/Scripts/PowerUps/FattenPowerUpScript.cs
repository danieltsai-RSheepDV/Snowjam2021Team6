using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FattenPowerUpScript : MonoBehaviour
{

    // Touch = collect
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            // Modify game state, usually the player ->
            other.GetComponentInParent<PlayerController>().AddVolume(1000f);
            // Done with object
            Destroy(this.gameObject);
        }
    }
}
