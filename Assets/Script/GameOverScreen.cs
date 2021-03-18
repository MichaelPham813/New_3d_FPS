using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
   public void RestartButton()
    {
        FindObjectOfType<GameManager>().EndGame();
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
