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

    public static void PauseSFX()
    {
        instance.sfxBus.setPaused(true);
    }

    public static void UnpauseSFX()
    {
        instance.sfxBus.setPaused(false);
    }
}
