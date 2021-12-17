using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeController : MonoBehaviour
{
    FMOD.Studio.Bus musicBus;
    Slider slider;
    float volume;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        musicBus = FMODUnity.RuntimeManager.GetBus("bus:/Music");
        musicBus.getVolume(out volume);
        slider.value = volume;
    }

    public void UpdateVolume()
    {
        volume = slider.value;
        musicBus.setVolume(Mathf.Pow(volume, 2f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
