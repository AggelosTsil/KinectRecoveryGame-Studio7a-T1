using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Power = 30;
    public float MaxPower = 100;

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
        if(Input.GetKeyDown("d")){
            SetPower(-20f);
        }
        if(Input.GetKeyDown("h")){
            SetPower(+20f);
        }
    }

    public void SetPower(float powerChange){
        Power += powerChange;
        Power = Mathf.Clamp(Power, 0, MaxPower);

        powerBar.SetPower(Power);
    }
}
