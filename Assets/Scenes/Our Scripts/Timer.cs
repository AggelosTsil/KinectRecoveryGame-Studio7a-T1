using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 60.0f;

    public Text timertext;
    bool start;

    void Start()
    {

    }
    public void BeginTimer(InputAction.CallbackContext context)
    {
        start = true;
        Debug.Log("Timer started");
    }

    public void StopTimer(InputAction.CallbackContext context)
    {
        start = false;
        Debug.Log("Timer stoped");
    }
    void Update()
    {

        if (start == true)
        {

            timer -= Time.deltaTime;

            if (timer <= 0.0f)
            {
                TimerEnded();
            }

            timertext.text = timer.ToString("n1");
        }
    }
    void TimerEnded()
    {
        timertext.color = Color.red;
    }
}
