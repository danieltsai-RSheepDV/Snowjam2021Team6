using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSToggle : MonoBehaviour
{
    Toggle tg;
    // Start is called before the first frame update
    void Start()
    {
        tg = GetComponent<Toggle>();
        tg.isOn = Screen.fullScreen;
    }

}
