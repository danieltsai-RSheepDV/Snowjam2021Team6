using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundController : MonoBehaviour
{
    FMODUnity.StudioEventEmitter em;
    // Start is called before the first frame update
    void Start()
    {
        em = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPop()
    {
        em.Play();
    }
}
