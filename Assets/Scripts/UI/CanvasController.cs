using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    GameObject menu;
    GameObject options;
    GameObject credits;
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("Menu");
        options = GameObject.Find("Options");
        credits = GameObject.Find("Credits");
        ToggleMenu();
    }

    // Displays the menu
    public void ToggleMenu()
    {
        // Debug.Log("toggling");
        menu.SetActive(true);
        options.SetActive(false);
        credits.SetActive(false);
    }

    // Displays the options
    public void ToggleOptions()
    {
        menu.SetActive(false);
        options.SetActive(true);
        credits.SetActive(false);
    }

    // Displays the credits
    public void ToggleCredits()
    {
        menu.SetActive(false);
        options.SetActive(false);
        credits.SetActive(true);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

}
