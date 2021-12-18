using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManagerSingleton
{
    static FMOD.Studio.Bus musicBus = FMODUnity.RuntimeManager.GetBus("bus:/Music");
    static FMOD.Studio.Bus sfxBus = FMODUnity.RuntimeManager.GetBus("bus:/SFX");
    static FMOD.Studio.Bus uiBus = FMODUnity.RuntimeManager.GetBus("bus:/UI");

    public static float GetMusicVolume()
    {
        float volume;
        musicBus.getVolume(out volume);
        return volume;
    }

    public static float GetSFXVolume()
    {
        float volume;
        sfxBus.getVolume(out volume);
        return volume;
    }

    public static float GetUIVolume()
    {
        float volume;
        uiBus.getVolume(out volume);
        return volume;
    }

    // Volume between 0f and 1f
    public static void SetMusicVolume(float volume)
    {
        musicBus.setVolume(volume);
    }

    // Volume between 0f and 1f
    public static void SetSFXVolume(float volume)
    {
        sfxBus.setVolume(volume);
    }

    // Volume between 0f and 1f
    public static void SetUIVolume(float volume)
    {
        uiBus.setVolume(volume);
    }

    public static void PauseSFX()
    {
        sfxBus.setPaused(true);
    }

    public static void UnpauseSFX()
    {
        sfxBus.setPaused(false);
    }
}
