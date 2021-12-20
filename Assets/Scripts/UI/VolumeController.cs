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

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoadRuntimeMethod()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
            SoundManagerSingleton.SetMusicVolume(PlayerPrefs.GetFloat("musicVolume"));
        if (PlayerPrefs.HasKey("SFXVolume"))
            SoundManagerSingleton.SetMusicVolume(PlayerPrefs.GetFloat("SFXVolume"));
        if (PlayerPrefs.HasKey("UIVolume"))
            SoundManagerSingleton.SetMusicVolume(PlayerPrefs.GetFloat("UIVolume"));
    }

    private void Start()
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
        slider.value = Mathf.Pow(volume, 0.25f);
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

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("musicVolume", SoundManagerSingleton.GetMusicVolume());
        PlayerPrefs.SetFloat("SFXVolume", SoundManagerSingleton.GetSFXVolume());
        PlayerPrefs.SetFloat("UIVolume", SoundManagerSingleton.GetUIVolume());
    }
}
