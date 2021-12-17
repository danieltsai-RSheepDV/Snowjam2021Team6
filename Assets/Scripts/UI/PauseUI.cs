using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    // Canvasses
    GameObject main;
    GameObject options;

    // Start is called before the first frame update
    void Start()
    {
        main = GameObject.Find("Main");
        options = GameObject.Find("Options");
    }

    private void OnEnable()
    {
        main.SetActive(true);
        options.SetActive(false);
    }

    public void ToggleOptions()
    {
        main.SetActive(false);
        options.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
