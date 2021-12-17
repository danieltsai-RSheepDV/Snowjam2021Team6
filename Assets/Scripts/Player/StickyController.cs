using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class StickyController : MonoBehaviour
{
    private PlayerController playerController;
    private List<KeyValuePair<StickableObject, float>> objects = new List<KeyValuePair<StickableObject, float>>();
    
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

            if (playerController.GetRadius() > s.radiusLimit)
            {
                s.disableObject();
                s.transform.parent = transform;
                playerController.AddGrowthRate(playerController.growthValue * 0.25f);
                
                objects.Add(new KeyValuePair<StickableObject, float>(s, playerController.GetRadius()));
            }
        }
    }
    
    public void DropObjects()
    {
        foreach(var val in objects.ToList())
        {
            if (playerController.GetRadius() < val.Value - 1)
            {
                val.Key.enableObject(playerController.transform);
                val.Key.transform.parent = null;
                
                objects.Remove(val);
                Debug.Log(objects.Count);
            }
        }
    }
}