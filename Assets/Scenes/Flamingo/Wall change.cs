using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class Wallchange : MonoBehaviour
{
    public PoseDetectorScript pose;

    public PoseModelHelper RightLeg;
    public PoseModelHelper LeftLeg;
    public Material Footdown;
    public Material Footup;

    public Text ChangeText;

    public SpriteRenderer flamingo_hat_spriteRenderer;

    public SpriteRenderer flamingo_kariolis_spriteRenderer;

    public SpriteRenderer flamingo_normal_spriteRenderer;

    public float Timer;
    public float ChangeTextLifespan;
    float TimerIni;
    // Start is called before the first frame update
    void Start()
    {
        TimerIni = Timer;
    }

    void FlamingoFlip()
    {
        flamingo_hat_spriteRenderer.flipX = !flamingo_hat_spriteRenderer.flipX;
        flamingo_kariolis_spriteRenderer.flipX = !flamingo_kariolis_spriteRenderer.flipX;
        flamingo_normal_spriteRenderer.flipX = !flamingo_normal_spriteRenderer.flipX;
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
            gameObject.GetComponent<MeshRenderer>().material = Footup;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = Footdown;
        }
    }
}
