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

    // Touch = collect
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            // Modify game state, usually the player ->
            PlayerController pc = other.GetComponentInParent<PlayerController>();
            if (pc.GetVolume() > 100f) {
                pc.AddVolume(-1000f);
            } else {
                pc.AddVolume(-1000f);
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
