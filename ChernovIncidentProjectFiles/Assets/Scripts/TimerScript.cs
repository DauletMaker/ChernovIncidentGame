using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TMP_Text timeText;   
    public float startTime = 600f;

    private float remainingTime;
    private bool timerRunning = false;


    void Start()
    {
        remainingTime = startTime;
        timerRunning = true;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!timerRunning) return;

        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            timerRunning = false;
            UpdateTimerDisplay();

            //Invoke an event

            return;
        }

        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        int hundredths = Mathf.FloorToInt((remainingTime * 100f) % 100f);

        timeText.text = $"{minutes:00}:{seconds:00}:{hundredths:00}";
    }
}
