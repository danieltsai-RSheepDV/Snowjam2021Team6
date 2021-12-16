using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private const int CameraMinValue = 5;
    private const int CameraMaxValue = 70;

    private float power;
    private float volume;
    
    private Rigidbody rb;

    [SerializeField] private CinemachineVirtualCamera vcam;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject model;

    public float maxShootPower = 100;
    public float minShootPower = 0;
    public float growthRate = 1;

    // Lifecycle
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        volume = radiusToVolume(transform.localScale.x);
    }
    
    void Update()
    {
        
    }

    //Events

    void OnLook(InputValue inputValue)
    {
        power += inputValue.Get<Vector2>().y;
        power = Mathf.Clamp(power, minShootPower, maxShootPower);
    }
    
    void OnShootDown()
    {
        vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MinValue =
            vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value;
        vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxValue =
            vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value;
        
        power = 0f;
    }

    void OnShootUp(InputValue value)
    {
        rb.velocity = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized * power;
        
        vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MinValue =
            CameraMinValue;
        vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxValue =
            CameraMaxValue;
    }
    
    private void OnCollisionStay(Collision other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            volume += growthRate * Time.deltaTime * rb.velocity.magnitude;
            model.transform.localScale = Vector3.one * volumeToRadius(volume);
        }
    }
    
    //Methods

    public float radiusToVolume(float radius)
    {
        return (float) ((4f / 3f) * Math.PI * Math.Pow(radius, 3));
    }
    
    public float volumeToRadius(float volume)
    {
        return (float) Math.Pow((volume * 3f) / (4f * Math.PI), (1f/3f));
    }
    
    public float GetPower()
    {
        return power;
    }
}
