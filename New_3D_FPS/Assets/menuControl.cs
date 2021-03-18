using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{
    public Transform cam;
    private int i=0, mov=1;
    private void Awake() {
        Time.timeScale=1;
    }
   public void TutorialMap(){
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }
    public void NormalMap(){
        SceneManager.LoadScene(2,LoadSceneMode.Single);
    }
    public void Menu(){
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
    public void Exit(){
        Application.Quit();
    }

}
