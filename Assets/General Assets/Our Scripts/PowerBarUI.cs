using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBarUI : MonoBehaviour
{
    public float Power, MaxPower, Width, Height;
    
    [SerializeField]
    private RectTransform powerBar;

    public void SetMaxPower(float maxPower){
        MaxPower = maxPower;
    }

    public void SetPower(float power){
        Power = power;
        float newWidth = (Power/MaxPower)*Width;

        powerBar.sizeDelta = new Vector2(newWidth, Height);
    }
}
