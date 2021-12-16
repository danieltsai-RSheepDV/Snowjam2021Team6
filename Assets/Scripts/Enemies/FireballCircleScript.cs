using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCircleScript : MonoBehaviour
{
    private Rigidbody rb;

    // Touch = collect
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            // Modify game state, usually the player ->
            PlayerController pc = other.GetComponentInParent<PlayerController>();
            if (pc.GetVolume() > 100f) {
                pc.AddVolume((-1f*pc.GetVolume()) + 1);
            } else {
                pc.AddVolume(-100f);
            }
            // Done with object
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
