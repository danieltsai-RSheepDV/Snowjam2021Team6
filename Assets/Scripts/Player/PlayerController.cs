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
    
    private Rigidbody rb;

    public CinemachineVirtualCamera vcam;
    public Camera cam;

    public float maxShootPower = 100;
    public float minShootPower = 0;
    
    // Lifecycle
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
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
    
    //Methods

    public float GetPower()
    {
        return power;
    }
}
