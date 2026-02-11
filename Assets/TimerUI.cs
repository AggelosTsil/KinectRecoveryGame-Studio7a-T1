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
    public PauseScreen pauseScreen;
    public float Timer;
    public float AdjustSensitivity;
    public bool Active;
    bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.instance != null)

        {
            Timer = DataManager.instance.CurrentSceneDuration;
             Active = false;
        }
        else
        {
            //Timer = 5f;
            Active = false;
        }
    }

    public void StartStop(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (finished)
            {
                if (DataManager.instance != null)
                {
                    DataManager.instance.CurrentGameIndex++;
                    StartGameButtton.LoadNextScene();
                }
                return;
            }
            Active = !Active;
            if (Active)
            {
                Debug.Log("Timer started");
            }
            else
            {
                Debug.Log("Timer stoped");
            }
            pauseScreen.Pause(Active);
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
        if (!Active || finished)
            return;

        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
            TimerActive();
        }
        else
        {
            finished = true;
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
