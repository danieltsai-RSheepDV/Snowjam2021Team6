using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StickableObject : MonoBehaviour
{
    public float radiusLimit;
    public float volume;

    private PlayerController playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disableObject()
    {
        Destroy(GetComponent<Rigidbody>());
        gameObject.GetComponent<Collider>().enabled = false;
    }
    
    public void enableObject(Transform t)
    {
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Collider>().enabled = true;
        gameObject.transform.position = t.position + Vector3.up * gameObject.transform.localPosition.magnitude * 2;
        
        double d = Random.Range(0f, 360f);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3((float) Math.Cos(d), 1f, (float) Math.Sin(d)) * gameObject.transform.localPosition.magnitude;
    }
}
