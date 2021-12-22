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
    private const float CameraInitSpeed = 0.4f;

    private const float mediumTreshold = 10f;
    private const float largeTreshold = 30f;

    private const float smallPowMod = 0.8f;
    private const float mediumPowMod = 1.6f;
    private const float largePowMod = 3.2f;

    private bool isGrounded;
    private bool canJump = true;
    private bool isAiming = false;
    private float power;
    private float powerModifier = smallPowMod;
    
    private float maxGrowthRate = 0.2f;
    private float growthRate = 1f;
    private float growthDecel = 0.01f;
    
    private SnowballSize snowballSize = SnowballSize.SMALL;

    private Rigidbody rb;

    [SerializeField] private CinemachineVirtualCamera vcam;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject model;
    [SerializeField] private Transform restartPoint;
    
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
        growthRate = growthValue;
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

        float sens = 1f;
        if(PlayerPrefs.HasKey("sensitivity"))
        {
            sens = PlayerPrefs.GetFloat("sensitivity");
        }
        vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = CameraInitSpeed * sens;
        vcam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = CameraInitSpeed * sens;
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
            
            rb.velocity = new Vector3(cam.transform.forward.x,  0f, cam.transform.forward.z).normalized * (power * powerModifier);

            vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MinValue =
                CameraMinValue;
            vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxValue =
                CameraMaxValue;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
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
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnRestart()
    {
        Debug.Log("test");
        transform.position = restartPoint.position;
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
                powerModifier = largePowMod;
                vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = 250f;
                Physics.gravity = new Vector3(0f, -50f, 0f);
                break;
            case SnowballSize.MEDIUM:
                minSize = mediumTreshold;
                powerModifier = mediumPowMod;
                vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = 150f;
                Physics.gravity = new Vector3(0f, -30f, 0f);
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
