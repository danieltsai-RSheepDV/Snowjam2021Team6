using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Object"))
        {
            Destroy(collision.rigidbody);
            collision.gameObject.layer = 6;
            collision.transform.parent = transform.parent;
        }
    }
}