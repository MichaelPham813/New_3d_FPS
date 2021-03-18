using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float timeSlow = 0.05f;
    public float timeLength = 2f;

    public PauseMenu pause;

    // Update is called once per frame
    void Update()
    {
        if (pause.gamePaused == false)
        {
            Time.timeScale += (1f / timeLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
        else
        {
            pause.Pause();
        }
    }



    public void SlowTime()
    {
        Time.timeScale = timeSlow;
        Time.fixedDeltaTime = Time.timeScale * .2f;
    }
}
