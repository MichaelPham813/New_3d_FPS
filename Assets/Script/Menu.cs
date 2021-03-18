using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool Start=false;
    public Animator transition;
    public float transitionTime = 1f;
    public void StartGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

        Start = true;
    }
    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);

    }
}
