using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeController : MonoBehaviour
{
    Slider slider;
    float volume;
    public enum SoundType
    {
        Music,
        SFX,
        UI
    }
    [SerializeField] public SoundType soundType;

    private void Awake()
    {
        switch (soundType)
        {
            case SoundType.Music:
                volume = SoundManagerSingleton.GetMusicVolume();
                break;
            case SoundType.SFX:
                volume = SoundManagerSingleton.GetSFXVolume();
                break;
            case SoundType.UI:
                volume = SoundManagerSingleton.GetUIVolume();
                break;
        }
        
        
        slider = GetComponent<Slider>();
        slider.value = volume;
    }

    public void UpdateMusicVolume()
    {
        volume = slider.value;
        SoundManagerSingleton.SetMusicVolume(Mathf.Pow(volume, 4));
    }

    public void UpdateUIVolume()
    {
        volume = slider.value;
        SoundManagerSingleton.SetUIVolume(Mathf.Pow(volume, 4));
    }

    public void UpdateSFXVolume()
    {
        volume = slider.value;
        SoundManagerSingleton.SetSFXVolume(Mathf.Pow(volume, 4));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
