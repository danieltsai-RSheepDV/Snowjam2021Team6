using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public enum SnowballSize
    {
        SMALL,
        MEDIUM,
        LARGE
    }

    private const int CameraMinValue = 5;
    private const int CameraMaxValue = 70;
    private const float ShootMaxVelocity = 1;
    private const float mediumTreshold = 300f;
    private const float largeTreshold = 2000f;

    private bool isGrounded;
    private float power;
    private float volume;
    private SnowballSize snowballSize = SnowballSize.SMALL;

    private Rigidbody rb;

    [SerializeField] private CinemachineVirtualCamera vcam;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject model;

    public float maxShootPower = 100f;
    public float minShootPower = 0f;
    public float growthRate = 1f;
    public float growthDecel = 1f;

    // Lifecycle
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        volume = radiusToVolume(model.transform.localScale.x);
    }
    
    void Update()
    {
        if (volume > largeTreshold)
        {
            snowballSize = SnowballSize.LARGE;
        }
        else if (volume > mediumTreshold)
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
        power = Mathf.Clamp(power, minShootPower, maxShootPower);
    }
    
    void OnShootDown()
    {
        if (CanShoot())
        {
            vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MinValue =
                vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value;
            vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxValue =
                vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value;
        }

        power = 0f;
    }

    void OnShootUp(InputValue value)
    {
        if (CanShoot())
        {
            rb.velocity = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized * power;

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
            volume += growthRate * Time.deltaTime * rb.velocity.magnitude;
            model.transform.localScale = Vector3.one * volumeToRadius(volume);
            
            growthRate -= Time.deltaTime * rb.velocity.magnitude;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            isGrounded = true;
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
        return isGrounded && rb.velocity.magnitude < ShootMaxVelocity;
    }

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

    public float GetVolume()
    {
        return volume;
    }

    public void AddVolume(float vol)
    {
        float tVol = volume + vol;
        Debug.Log(tVol);
        volume = tVol < 1f ? 1f : tVol;
    }

    public SnowballSize getSnowballSize()
    {
        return snowballSize;
    }
}
