using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalWind : MonoBehaviour
{
    public float windForce = 20f;

    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            other.attachedRigidbody.AddForce(gameObject.transform.forward * windForce, ForceMode.Acceleration);
        }
    }
}
