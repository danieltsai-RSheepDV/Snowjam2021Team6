using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    // Canvasses
    GameObject main;
    GameObject options;

    // Start is called before the first frame update
    void Awake()
    {
        main = GameObject.Find("Main");
        options = GameObject.Find("Options");
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        ToggleMenu();
    }

    public void ToggleOptions()
    {
        main.SetActive(false);
        options.SetActive(true);
    }

    public void ToggleMenu()
    {
        main.SetActive(true);
        options.SetActive(false);
    }

}
