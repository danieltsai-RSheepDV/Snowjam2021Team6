using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowballSFXTest
{
    public class SoundEmitter : MonoBehaviour
    {
        float speed = 0;

        FMODUnity.StudioEventEmitter rollingSFXEmitter;
        FMODUnity.StudioEventEmitter windSFXEmitter;
        FMODUnity.StudioEventEmitter hitSFXEmitter;

        void Awake()
        {
            rollingSFXEmitter = transform.Find("Rolling SFX").GetComponent<FMODUnity.StudioEventEmitter>();
            windSFXEmitter = transform.Find("Wind SFX").GetComponent<FMODUnity.StudioEventEmitter>();
            hitSFXEmitter = transform.Find("Hit SFX").GetComponent<FMODUnity.StudioEventEmitter>();
        }

        public void ChangeSpeed(float speed)
        {
            this.speed = speed;
            rollingSFXEmitter.SetParameter("Speed", speed);
            windSFXEmitter.SetParameter("Speed", speed);
        }

        public void ToggleOnFloor(bool isOnFloor)
        {
            if (isOnFloor)
            {
                rollingSFXEmitter.Play();
                rollingSFXEmitter.SetParameter("Speed", speed);
            }
            else
            {
                rollingSFXEmitter.Stop();
            }
        }

        public void PlayHit()
        {
            hitSFXEmitter.Play();
        }
    }
}