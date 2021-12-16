using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCircleScript : MonoBehaviour
{

    [SerializeField] private float meltRate = 0.01f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Stay = melted
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            // Modify game state, usually the player ->
            PlayerController pc = other.GetComponentInParent<PlayerController>();
            pc.AddRadius(-meltRate);
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
