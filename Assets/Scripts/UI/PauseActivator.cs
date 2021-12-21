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
        
    }

    public void OnPause()
    {
        if (paused)
        {
            unpauseGame();
        }
        else
        {
            pauseGame();
        }
    }

    public void unpauseGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseUI.SetActive(false);
        paused = false;
        Time.timeScale = 1;
        SoundManagerSingleton.UnpauseSFX();
    }

    public void pauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseUI.SetActive(true);
        paused = true;
        Time.timeScale = 0;
        SoundManagerSingleton.PauseSFX();
    }
    public void LoadScene(string name)
    {
        
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(name);
    }
}
