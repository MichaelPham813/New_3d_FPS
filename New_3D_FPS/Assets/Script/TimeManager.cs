using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float timeSlow = 0.05f;
    public float timeLength = 2f;
    public PauseMenu pause;
    public TimeStop timeStop;
    public float timeDuration = 3.5f;
    private float elapsedTime;
    private void Awake()
    {
       elapsedTime = timeDuration;
    }
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

        if (timeStop.TimeStopped==true)
       {
           timeDuration -= (elapsedTime * Time.deltaTime)/5;
           timeDuration = Mathf.Clamp(timeDuration,0,elapsedTime);
           Debug.Log(timeDuration);
       }
       if(timeDuration == 0)
       {
           timeStop.TimeResume();
       }
        
    }



    public void SlowTime()
    {
        Time.timeScale = timeSlow;
        Time.fixedDeltaTime = Time.timeScale * .2f;
    }
}
