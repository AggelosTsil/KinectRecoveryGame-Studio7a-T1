using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Power = 0;
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
        
    }

    public void SetPower(float powerChange){
        Power += powerChange;
        Power = Mathf.Clamp(Power, 0, MaxPower);

        powerBar.SetPower(Power);
    }
}
