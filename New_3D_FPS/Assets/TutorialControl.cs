using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutorialControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseCanvas;
    public GameObject playerUI;
    private bool IsPause;
    
    private void Awake() {
        Time.timeScale=1;
        PauseCanvas.SetActive(false);
        IsPause = false;
        
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Pause();
        }
           
    }

    public void Pause(){
        IsPause = !IsPause;
        PauseCanvas.SetActive(IsPause);
        playerUI.SetActive(!IsPause);
        if(IsPause){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = IsPause;
            Time.timeScale = 0;
        } 
        else {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = IsPause;
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    public void EndTutorial(){
        Time.timeScale=0.5f;
        Invoke(nameof(LoadScene2),1f);
    }

    public void LoadScene2(){
        SceneManager.LoadScene(2,LoadSceneMode.Single);
    }
    public void LoadMenu(){
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }

}    
