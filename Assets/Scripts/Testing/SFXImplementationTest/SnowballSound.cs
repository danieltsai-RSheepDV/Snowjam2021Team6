using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFXImplementationTest
{
    public class SnowballSound : CollisionListener
    {
        public Rigidbody snowballRigidbody;

        [Range(0f, 1f)]
        public float smoothTime;

        FMODUnity.StudioEventEmitter rollingSFXEmitter;
        FMODUnity.StudioEventEmitter windSFXEmitter;
        FMODUnity.StudioEventEmitter hitSFXEmitter;
        FMODUnity.StudioEventEmitter whooshSFXEmitter;

        float soundSpeed = 0;
        float soundSpeedVelocity;

        void Awake()
        {
            rollingSFXEmitter = transform.Find("Rolling SFX").GetComponent<FMODUnity.StudioEventEmitter>();
            windSFXEmitter = transform.Find("Wind SFX").GetComponent<FMODUnity.StudioEventEmitter>();
            hitSFXEmitter = transform.Find("Hit SFX").GetComponent<FMODUnity.StudioEventEmitter>();
            whooshSFXEmitter = transform.Find("Whoosh SFX").GetComponent<FMODUnity.StudioEventEmitter>();

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

            Debug.Log($"Sound speed: {soundSpeed}");
            rollingSFXEmitter.SetParameter("Speed", soundSpeed);
            windSFXEmitter.SetParameter("Speed", soundSpeed);
        }

        public override void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"Hit!");

            hitSFXEmitter.Play();

            if (collision.transform.CompareTag("Ground"))
            {
                Debug.Log($"Grounded!");
                rollingSFXEmitter.Play();
                rollingSFXEmitter.SetParameter("Speed", soundSpeed);
            }
        }

        public override void OnCollisionExit(Collision collision)
        {
            Debug.Log($"Unhit!");

            if (collision.transform.CompareTag("Ground"))
            {
                Debug.Log($"Lift off!");
                rollingSFXEmitter.Stop();
                whooshSFXEmitter.Play();
            }
        }
    }
}