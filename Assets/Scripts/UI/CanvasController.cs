using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    GameObject menu;
    GameObject options;
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("Menu");
        options = GameObject.Find("Options");
    }

    // Displays the menu
    public void ToggleMenu()
    {
        menu.SetActive(true);
        options.SetActive(false);
    }

    // Displays the options
    public void ToggleOptions()
    {
        menu.SetActive(false);
        options.SetActive(true);
    }

}
