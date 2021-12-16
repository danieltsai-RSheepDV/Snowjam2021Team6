using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class StickyController : MonoBehaviour
{

    [SerializeField] private GameObject model;
    
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<StickableObject>() != null)
        {
            StickableObject s = other.gameObject.GetComponent<StickableObject>();

            if (model.transform.localScale.x > s.radiusLimit)
            {
                Destroy(other.rigidbody);
                Destroy(other.collider);
                other.transform.parent = transform;
            
                playerController.AddVolume(s.volume);
            }
        }
    }
}