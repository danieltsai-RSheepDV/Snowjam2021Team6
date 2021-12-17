using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseActivator : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    bool paused;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (paused)
            {
                unpauseGame();
            } else
            {
                pauseGame();
            }

        }
    }

    public void unpauseGame()
    {
        pauseUI.SetActive(false);
        paused = false;
        Time.timeScale = 1;
    }

    public void pauseGame()
    {
        pauseUI.SetActive(true);
        paused = true;
        Time.timeScale = 0;
    }
    public void LoadScene(string name)
    {
        unpauseGame();
        SceneManager.LoadScene(name);
    }
}
