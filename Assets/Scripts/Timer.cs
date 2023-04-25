using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60; // the initial time for the countdown
    public Text countdownText; // the UI Text object to display the countdown
    public GameObject Pause;
    public GameObject Pass;
    public GameObject lose;
    void Update()
    {
        if ((!Pass.activeSelf)&&(!Pause.activeSelf)&&(!lose.activeSelf))
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // reduce the remaining time by the time passed since last frame
                UpdateCountdownText(); // update the UI text
            }
            else
            {
                // the countdown is over, do something here
                lose.SetActive(true);
            }
        }
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
