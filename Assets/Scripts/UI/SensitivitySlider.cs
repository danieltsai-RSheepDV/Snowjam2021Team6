using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SensitivitySlider : MonoBehaviour
{
    Slider sl;
    // Start is called before the first frame update
    void Start()
    {
        sl = GetComponent<Slider>();
        sl.value = PlayerPrefs.GetFloat("sensitivity");
    }

}
