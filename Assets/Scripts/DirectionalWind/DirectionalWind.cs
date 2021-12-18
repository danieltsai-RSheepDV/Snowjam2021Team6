using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalWind : MonoBehaviour
{
    public float windForce = 20f;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.attachedRigidbody.AddForce(gameObject.transform.forward * windForce, ForceMode.Acceleration);
        }
    }
}
