using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(ParticleSystem))]

public class StickableObject : MonoBehaviour
{
    public float radiusLimit;
    public float volume;

    private bool limitPassed = false;
    private bool disabled = false;
    private ParticleSystem particleSystem;
    private PlayerController playerController;
    private ParticleSystemRenderer rd;
    
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        var mn = particleSystem.main;
        mn.startLifetime = 1;
        mn.startSpeed = 0;
        mn.startSize = 0.4f / transform.localScale.x;
        var em = particleSystem.emission;
        em.enabled = true;
        em.rateOverTime = 50;
        var sh = particleSystem.shape;
        sh.enabled = true;
        sh.shapeType = ParticleSystemShapeType.MeshRenderer;
        sh.meshShapeType = ParticleSystemMeshShapeType.Triangle;
        sh.meshRenderer = GetComponent<MeshRenderer>();
        sh.scale = Vector3.one * 1.2f;
        rd = particleSystem.GetComponent<ParticleSystemRenderer>();
        rd.material = GameObject.FindWithTag("Sparkles").GetComponent<Renderer>().material;

        playerController = GameObject.Find("Snowball").GetComponent<PlayerController>();
        playerController.sizeChanged.AddListener(checkSize);

        particleSystem.Stop();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (limitPassed && !disabled)
        {
            if (particleSystem.isStopped)
            {
                particleSystem.Play();
                rd.enabled = true;
            }
        }
        else
        {
            rd.enabled = false;
            particleSystem.Stop();
        }
    }

    private void checkSize()
    {
        limitPassed = playerController.GetRadius() > radiusLimit;
    }
    
    public void disableObject()
    {
        Destroy(GetComponent<Rigidbody>());
        foreach (Collider collider in gameObject.GetComponents<Collider>())
        {
            collider.enabled = false;
        }

        disabled = true;
    }
    
    public void enableObject(Transform t)
    {
        gameObject.AddComponent<Rigidbody>();
        foreach (Collider collider in gameObject.GetComponents<Collider>())
        {
            collider.enabled = true;
        }
        gameObject.transform.position = t.position + Vector3.up * gameObject.transform.localPosition.magnitude * 2;
        
        double d = Random.Range(0f, 360f);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3((float) Math.Cos(d), 1f, (float) Math.Sin(d)) * gameObject.transform.localPosition.magnitude;

        disabled = false;
    }
}
