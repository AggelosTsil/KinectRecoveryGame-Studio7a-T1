using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Timers;
using System;
using UnityEngine.InputSystem;
public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI UITimer;
    public float Timer;
    public float AdjustSensitivity;
    bool Active;
    // Start is called before the first frame update
    void Start()
    {
        Active = false;
    }

    public void StartStop(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Active = !Active;
            if (Active)
            {
                Debug.Log("Timer started");
            }
            else
            {
                Debug.Log("Timer stoped");
            }
        }
        
    }

    public void AdjustTime(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            float var = context.ReadValue<float>();
            Timer -= var*AdjustSensitivity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Active)
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
