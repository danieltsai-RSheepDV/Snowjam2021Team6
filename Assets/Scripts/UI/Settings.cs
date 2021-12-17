using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("sensitivity"))
            PlayerPrefs.SetFloat("sensitivity", 1f);
    }

    public void SetSensitivity(float val)
    {
        PlayerPrefs.SetFloat("sensitivity", val);
    }

    public void ToggleFullscreen(bool toggle)
    {
        Screen.fullScreen = toggle;
    }


}
