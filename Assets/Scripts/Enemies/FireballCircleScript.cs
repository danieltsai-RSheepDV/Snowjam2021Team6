using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCircleScript : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Stay = melted
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            // Modify game state, usually the player ->
            PlayerController pc = other.GetComponentInParent<PlayerController>();
            if (pc.getSnowballSize() == PlayerController.SnowballSize.SMALL) {
                pc.AddVolume(-5f);
            } else if (pc.getSnowballSize() == PlayerController.SnowballSize.MEDIUM) {
                pc.AddVolume(-15f);
            } else {
                // Large
                pc.AddVolume(-75f);
            }
            // Done with object?
            // Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(5f*Mathf.Sin(transform.position.x / 100f), 0f, 0f);
    }
}
