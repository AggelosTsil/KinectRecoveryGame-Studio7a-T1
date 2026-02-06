using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

public class MinutesToSeconds : MonoBehaviour
{
    public GameObject MinutesGO;
    public GameObject SecondsGO;
    public MinutesToSeconds other;
    private float x;
    private float y;

    public void Update()
    {
        if (this.GetComponent<TMP_InputField>().text == "") this.GetComponent<TMP_InputField>().text = "00";
    }
    public void SetVaulue()
    {
        TMP_InputField Minutes = MinutesGO.GetComponent<TMP_InputField>();
        TMP_InputField Seconds = SecondsGO.GetComponent<TMP_InputField>();
        x = 0;
        y = 0;
        if (this.name == "Minutes")
        {
            other = SecondsGO.GetComponent<MinutesToSeconds>();
            if (Minutes.text != "")
            {
                x = Int32.Parse(Minutes.text);
            }
            else x = 0;
            y = other.y;
        }
        else if (this.name == "Seconds")
        {
            other = MinutesGO.GetComponent<MinutesToSeconds>();
            if (Seconds.text != "")
            {
                y = Int32.Parse(Seconds.text);
            }
            else y = 0;
            x = other.x;
        }
        //UnityEngine.Debug.Log(CalculateTime(x, y));
        DataManager.instance.TransportValue = CalculateTime(x,y);
        UnityEngine.Debug.Log(DataManager.instance.TransportValue);

    }

    public float CalculateTime(float x, float y)
    {
        float value1 = x * 60f;
        float value2 = y;
        float FinalTime = value1 + value2;
        return FinalTime;
        
    }

}
