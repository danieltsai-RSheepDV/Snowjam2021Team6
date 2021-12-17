using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerSingleton : MonoBehaviour
{
    static SoundManagerSingleton instance;

    FMOD.Studio.Bus musicBus;
    FMOD.Studio.Bus sfxBus;
    FMOD.Studio.Bus uiBus;

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        musicBus = FMODUnity.RuntimeManager.GetBus("bus:/Music");
        sfxBus = FMODUnity.RuntimeManager.GetBus("bus:/SFX");
        uiBus = FMODUnity.RuntimeManager.GetBus("bus:/UI");
    }

    // Volume between 0f and 1f
    public static void SetMusicVolume(float volume)
    {
        instance.musicBus.setVolume(volume);
    }

    // Volume between 0f and 1f
    public static void SetSFXVolume(float volume)
    {
        instance.sfxBus.setVolume(volume);
    }

    // Volume between 0f and 1f
    public static void SetUIVolume(float volume)
    {
        instance.uiBus.setVolume(volume);
    }

    public static void PauseSFX()
    {
        instance.sfxBus.setPaused(true);
    }

    public static void UnpauseSFX()
    {
        instance.sfxBus.setPaused(false);
    }
}
