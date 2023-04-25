using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60; // the initial time for the countdown
    public Text countdownText; // the UI Text object to display the countdown
    public bool isTimerPaused = false;
    [SerializeField] GameController gameController;
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // reduce the remaining time by the time passed since last frame
        }
        else
        {
            timeRemaining = 0;
            // the countdown is over, do something here
            gameController.timerExpired();
        }
        UpdateCountdownText();
    }

    void UpdateCountdownText()
    {
        // convert the remaining time to a formatted string to display in the UI text
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        countdownText.text = timeString;
    }
}
