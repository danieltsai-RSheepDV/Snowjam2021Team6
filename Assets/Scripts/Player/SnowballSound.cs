using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSound : CollisionListener
{
    public Rigidbody snowballRigidbody;

    [Range(0f, 1f)]
    public float smoothTime;

    FMODUnity.StudioEventEmitter rollingSFXEmitter;
    FMODUnity.StudioEventEmitter windSFXEmitter;
    FMODUnity.StudioEventEmitter whooshSFXEmitter;
    FMODUnity.StudioEventEmitter hitSFXEmitter;
    FMODUnity.StudioEventEmitter powerUpSFXEmitter;

    float soundSpeed = 0;
    float soundSpeedVelocity;

    int groundCount = 0;

    void Awake()
    {
        rollingSFXEmitter = transform.Find("Rolling SFX").GetComponent<FMODUnity.StudioEventEmitter>();
        windSFXEmitter = transform.Find("Wind SFX").GetComponent<FMODUnity.StudioEventEmitter>();
        hitSFXEmitter = transform.Find("Hit SFX").GetComponent<FMODUnity.StudioEventEmitter>();
        whooshSFXEmitter = transform.Find("Whoosh SFX").GetComponent<FMODUnity.StudioEventEmitter>();
        powerUpSFXEmitter = transform.Find("Power Up SFX").GetComponent<FMODUnity.StudioEventEmitter>();

        windSFXEmitter.SetParameter("Speed", soundSpeed);
    }

    void Update()
    {
        float speed = snowballRigidbody.velocity.magnitude;

        if (speed > 100)
        {
            speed = 100;
        }

        soundSpeed = Mathf.SmoothDamp(soundSpeed, speed, ref soundSpeedVelocity, smoothTime);

        rollingSFXEmitter.SetParameter("Speed", soundSpeed);
        windSFXEmitter.SetParameter("Speed", soundSpeed);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        hitSFXEmitter.Play();

        if (collision.transform.CompareTag("Ground"))
        {
            rollingSFXEmitter.Play();
            rollingSFXEmitter.SetParameter("Speed", soundSpeed);
        }
    }

    public override void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            rollingSFXEmitter.Stop();
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            groundCount++;
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            groundCount--;

            if (groundCount <= 0)
            {
                whooshSFXEmitter.Play();
            }
        }
    }

    public void PlayPowerUpSFX()
    {
        powerUpSFXEmitter.Play();
    }
}
