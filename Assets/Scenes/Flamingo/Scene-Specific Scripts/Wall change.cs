using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class Wallchange : MonoBehaviour
{
    public PoseDetectorScript pose;
    public Player player;

    public PoseModelHelper RightLeg;
    public PoseModelHelper LeftLeg;
    public Material Footdown;
    public Material Footup;

    public Text ChangeText;

    public SpriteRenderer[] flamingoSprites;

    public float Timer;
    public float ChangeTextLifespan;
    float TimerIni;
    // Start is called before the first frame update
    void Start()
    {
        TimerIni = Timer;
        CountFlamingos();
    }

    void FlamingoFlip()
    {
        foreach (SpriteRenderer flamingo in flamingoSprites)
        {
            flamingo.flipX = !flamingo.flipX;
        }
    }

    public void CountFlamingos() //Adds a flamingo to the flamingoSprites Array. Checks what cell to put them in
    {
        flamingoSprites = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer >= 0)
        {
            Timer -= Time.deltaTime;
        }
        else if (Timer == Timer - ChangeTextLifespan)
        {
            ChangeText.text = "";
        }
        else
        {
            Timer = TimerIni;
            if (pose.poseModel == RightLeg)
            {
                pose.poseModel = LeftLeg;
                ChangeText.text = "Lift RIGHT Leg";
                FlamingoFlip();
            }
            else
            {
                pose.poseModel = RightLeg;
                ChangeText.text = "Lift LEFT Leg";
                FlamingoFlip();

            }
        }
    }

    void LateUpdate()
    {
        if (pose.IsPoseMatched())
        {
            //gameObject.GetComponent<MeshRenderer>().material = Footup;
            player.SetPower(Time.deltaTime * 5);
        }
        else
        {
            //gameObject.GetComponent<MeshRenderer>().material = Footdown;
            player.SetPower(-Time.deltaTime);
        }
    }
}
