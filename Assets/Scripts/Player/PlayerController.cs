using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{ 
    public enum SnowballSize
    {
        SMALL,
        MEDIUM,
        LARGE
    }

    public UnityEvent sizeChanged = new UnityEvent();

    private const int CameraMinValue = 5;
    private const int CameraMaxValue = 70;

    private const float mediumTreshold = 10f;
    private const float largeTreshold = 300f;

    private bool isGrounded;
    private bool canJump = true;
    private bool isAiming = false;
    private float power;
    
    private float maxGrowthRate = 0.2f;
    private float growthRate = 1f;
    private float growthDecel = 0.01f;
    
    private SnowballSize snowballSize = SnowballSize.SMALL;

    private Rigidbody rb;

    [SerializeField] private CinemachineVirtualCamera vcam;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject model;
    
    public float growthValue = 0.1f;
    [SerializeField] private float percentageGrowthDecel = 0.1f;
    [SerializeField] private float percentageMaxGrowthRate = 1.5f;

    // Lifecycle
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

        growthDecel = growthValue * percentageGrowthDecel;
        maxGrowthRate = percentageMaxGrowthRate * growthValue;
        growthRate = maxGrowthRate;
    }
    
    void Update()
    {
        
        if (GetRadius() >= largeTreshold)
        {
            snowballSize = SnowballSize.LARGE;
        }
        else if (GetRadius() >= mediumTreshold)
        {
            snowballSize = SnowballSize.MEDIUM;
        }
        else
        {
            snowballSize = SnowballSize.SMALL;
        }
    }

    //Events

    void OnLook(InputValue inputValue)
    {
        power += inputValue.Get<Vector2>().y;
        power = Mathf.Clamp(power, 10f, 100f);
    }
    
    void OnShootDown()
    {
        if (CanShoot())
        {
            isAiming = true;
            
            vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MinValue =
                vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value;
            vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxValue =
                vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value;
        }

        power = 0f;
    }

    void OnShootUp(InputValue value)
    {
        if (CanShoot() && isAiming)
        {
            if (!isGrounded) canJump = false;
            
            isAiming = false;
            
            rb.velocity = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized * (power);

            vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MinValue =
                CameraMinValue;
            vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxValue =
                CameraMaxValue;
        }
    }
    
    private void OnCollisionStay(Collision other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            AddRadius(growthRate * Time.deltaTime * (rb.velocity.magnitude/100f));
            
            AddGrowthRate(-Time.deltaTime * growthDecel * (rb.velocity.magnitude/100));
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            isGrounded = true;
            canJump = true;
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    //Methods

    public bool CanShoot()
    {
        return isGrounded || canJump; //&& rb.velocity.magnitude < ShootMaxVelocity;;
    }
    
    public float GetPower()
    {
        return power;
    }

    public float GetRadius()
    {
        return model.transform.localScale.x;
    }

    private void SetRadius(float val)
    {
        model.transform.localScale = Vector3.one * val;
    }

    public void AddRadius(float vol)
    {
        float tVol = GetRadius() + vol;
        float minSize = 1f;
        switch (snowballSize)
        {
            case SnowballSize.LARGE:
                minSize = largeTreshold;
                vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = 50;
                break;
            case SnowballSize.MEDIUM:
                minSize = mediumTreshold;
                
                break;
        }
        SetRadius(tVol < minSize ? minSize : tVol);
        
        sizeChanged.Invoke();
    }

    public void AddGrowthRate(float val)
    {
        growthRate += val;
        growthRate = Mathf.Clamp(growthRate, growthValue * 0.1f, maxGrowthRate);
    }

    public SnowballSize getSnowballSize()
    {
        return snowballSize;
    }

    public bool GetIsAiming()
    {
        return isAiming;
    }
}
