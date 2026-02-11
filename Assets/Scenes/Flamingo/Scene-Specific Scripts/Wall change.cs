
using System.Collections.Generic;
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
    public GameObject FlamingoZone;

    public Text ChangeText;
    public Image image;
    public Sprite LeftSprite;
    public Sprite RightSprite;
    public List<SpriteRenderer> flamingoSprites;

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

    public void CountFlamingos() //Adds a flamingo to the flamingoSprites Array. Also initialises <<After a couple of fixes this is kind of overenginnered but oh well>>
    {
        foreach (Transform child in FlamingoZone.transform)
        {
            if (!child.gameObject.CompareTag("dead")) //fix for flamingos that are currently dying while CountFlamingos is called
            {
                flamingoSprites.Add(child.Find("sprite").GetComponent<SpriteRenderer>());
                Debug.Log("added " + child + " to list");
            }
        }
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
                //ChangeText.text = "Lift RIGHT Leg";
                image.sprite = RightSprite;
                FlamingoFlip();
            }
            else
            {
                pose.poseModel = RightLeg;
                //ChangeText.text = "Lift LEFT Leg";
                image.sprite = LeftSprite;
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
