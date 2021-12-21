using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StickableObject : MonoBehaviour
{
    public float radiusLimit;
    public float volume;

    private bool limitPassed = false;
    private bool disabled = false;
    private GameObject particleOb;
    private PlayerController playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        particleOb = new GameObject();
        particleOb.transform.parent = transform;
        particleOb.transform.localScale = Vector3.one;

        ParticleSystem ps = particleOb.AddComponent<ParticleSystem>();
        var mn = ps.main;
        mn.startLifetime = 1;
        mn.startSpeed = 0;
        mn.startSize = 0.4f * Mathf.Pow(GetComponent<Collider>().bounds.size.magnitude, 1f/2f);
        var em = ps.emission;
        em.enabled = true;
        em.rateOverTime = 50;
        var sh = ps.shape;
        sh.meshRenderer = GetComponent<MeshRenderer>();
        sh.enabled = true;
        sh.shapeType = ParticleSystemShapeType.MeshRenderer;
        sh.meshShapeType = ParticleSystemMeshShapeType.Triangle;
        sh.scale = Vector3.one * 1.2f;
        ParticleSystemRenderer rd = ps.GetComponent<ParticleSystemRenderer>();
        rd.material = GameObject.FindWithTag("Sparkles").GetComponent<Renderer>().material;
        ps.Play();

        playerController = GameObject.Find("Snowball").GetComponent<PlayerController>();
        playerController.sizeChanged.AddListener(checkSize);

        ps.Stop();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (limitPassed && !disabled)
        {
            particleOb.SetActive(true);
        }
        else
        {
            particleOb.SetActive(false);
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
    
    Vector3 determineScale()
    {
 
        Vector3 tempScale = new Vector3(1, 1, 1);
        Transform t = transform;
        while (t != null)
        {
            tempScale = new Vector3(tempScale.x * t.localScale.x, tempScale.y * t.localScale.y, tempScale.z * t.localScale.z);
            t = t.parent;
        }
        return tempScale;
    }
}
