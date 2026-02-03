using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Timers;
using System;
public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI UITimer;
    public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
            TimerActive();
        }
        else
        {
            Timer = 0;
            TimerOver();
        }
        
    }

    private void TimerActive()
    {
        int minutes = Mathf.FloorToInt(Timer / 60);
        int seconds = Mathf.FloorToInt(Timer % 60);
        UITimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void TimerOver()
    {
        UITimer.text = "Well Done!";
    }
}
