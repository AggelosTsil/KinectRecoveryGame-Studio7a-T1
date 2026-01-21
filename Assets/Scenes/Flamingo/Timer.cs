using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 60.0f;

    public Text timertext;
    bool start;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            start = true;
        } //AGGELE KANTO SPACE anti gia mouse button

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
