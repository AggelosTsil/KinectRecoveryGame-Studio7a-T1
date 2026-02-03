using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Power = 0;
    public float MaxPower = 100;
    public bool PowerReady;
    public UnityEngine.UI.Image PowerReadyIndicator;

    [SerializeField]
    private PowerBarUI powerBar;
    
    // Start is called before the first frame update
    void Start()
    {
        powerBar.SetMaxPower(MaxPower);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPower(float powerChange){

        if (powerBar.Power > powerBar.MaxPower - 5) //player can do powerup at 95% power
        {
            Debug.Log("Power ready");
            PowerReadyIndicator.color = Color.green;
            PowerReady = true;
        }
        else if (PowerReady && (powerBar.Power < powerBar.MaxPower -5))
        {
            Debug.Log("Power wasted");
            PowerReadyIndicator.color = Color.red;
            PowerReady = false;
        }

        Power += powerChange;
        Power = Mathf.Clamp(Power, 0, MaxPower);

        powerBar.SetPower(Power);

    }
    public void UsePower()
    {
        Debug.Log("POW use power");
        //enter whatever the power does
        SetPower(-50);
    }
}
