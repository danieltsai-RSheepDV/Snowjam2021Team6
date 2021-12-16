using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FMODMusicDemo
{
    public class VolumeSlider : MonoBehaviour
    {
        FMOD.Studio.Bus sfxBus;
        Slider sfxSlider;
        float volume;

        void Awake()
        {
            sfxSlider = GetComponent<Slider>();
            sfxBus = FMODUnity.RuntimeManager.GetBus("bus:/Music");
            sfxBus.getVolume(out volume);
            sfxSlider.value = volume;
        }

        public void OnSFXValueChange()
        {
            volume = sfxSlider.value;
            sfxBus.setVolume(volume);
        }
    }
}