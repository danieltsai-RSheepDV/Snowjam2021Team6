using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowballSFXTest
{
    public class SoundEmitter : MonoBehaviour
    {
        FMODUnity.StudioEventEmitter rollingSFXEmitter;
        FMODUnity.StudioEventEmitter windSFXEmitter;
        float speed;

        void Awake()
        {
            rollingSFXEmitter = transform.Find("Rolling SFX").GetComponent<FMODUnity.StudioEventEmitter>();
            windSFXEmitter = transform.Find("Wind SFX").GetComponent<FMODUnity.StudioEventEmitter>();
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
    }
}