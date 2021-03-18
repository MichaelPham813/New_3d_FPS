using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public bool Victory = false;
    public GameObject VictoryUI;
    public GameObject playerUI;
    public GameObject playerCrosshair;
    public void Victor()
    {
        VictoryUI.SetActive(true);
        Time.timeScale = 0f;
        Victory = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerUI.SetActive(false);
        playerCrosshair.SetActive(false);
    }
   public void NextLevel()
    {
        FindObjectOfType<GameManager>().NextLevel();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        
    }
}
