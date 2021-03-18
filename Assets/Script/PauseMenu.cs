using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject pauseMenu;
    private TimeManager time;
    private PlayerMovement player;
    public GameObject playerUI;
    public GameObject playerCrosshair;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerUI.SetActive(true);
        playerCrosshair.SetActive(true);

    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerUI.SetActive(false);
        playerCrosshair.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        gamePaused = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
