using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCircleScript : MonoBehaviour
{

    [SerializeField] private float meltRate = 0.01f;
    private Rigidbody rb;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        startTime = Time.time;
        rb = GetComponent<Rigidbody>();
    }

    // Stay = melted
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            // Modify game state, usually the player ->
            PlayerController pc = other.GetComponentInParent<PlayerController>();
            pc.AddRadius(-meltRate);
/*
            //Old size-based tiers of volume removal
            if (pc.getSnowballSize() == PlayerController.SnowballSize.SMALL) {
                pc.AddVolume(-3f);
            } else if (pc.getSnowballSize() == PlayerController.SnowballSize.MEDIUM) {
                pc.AddVolume(-15f);
            } else {
                // Large
                pc.AddVolume(-75f);
            }
*/
            // Done with object?
            // Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    // Move the ball
    void Update()
    {
        float timeElapsed = Time.time - startTime;
        Vector3 pos = gameObject.transform.position;
        rb.velocity = new Vector3(10f*Mathf.Sin(timeElapsed / 3f), 8f*Mathf.Sin(timeElapsed / 0.5f), 10f*Mathf.Cos(timeElapsed / 3f));
        if (pos.y < 2.5f) {
            pos = new Vector3(pos.x, 2.5f, pos.z);
            gameObject.transform.position = pos;
        }
    }
}
