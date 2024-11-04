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

    private float[] rotationOptions = { 0f, 90f, 180f, 270f };
    private bool isRotating = false;
    private float start = 0f;
    private float end = 0f;
    IEnumerator RotateOverTime(float angle, float duration)
    {
        isRotating = true;

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(angle, 0, 0);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
        isRotating = false;
    }

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
                if (!isRotating)
                {

                    float randomAngle = rotationOptions[Random.Range(0, rotationOptions.Length)];

                    float rotationDuration = Mathf.Abs(transform.eulerAngles.x - randomAngle / 90f) * 2f;

                    StartCoroutine(RotateOverTime(randomAngle, 2f));
                }
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

