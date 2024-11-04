using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public Text TimerTxt;
    public float minTime = 5f;
    public float maxTime = 10f;

    private void Start()
    {
        TimerOn = true;
        RandomizeTime();
        TimerTxt.text = "";
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;

                if (TimeLeft <= 3)
                {
                    updateTimer(TimeLeft);
                }
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
                Debug.Log("Timer is Up");

                RestartTimer();
            }
        }
    }


    void updateTimer (float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    void RestartTimer()
    {
        RandomizeTime();
        TimerOn = true; 
        TimerTxt.text = "";
    }

    void RandomizeTime()
    {
        TimeLeft = Random.Range(minTime, maxTime);
    }
}

