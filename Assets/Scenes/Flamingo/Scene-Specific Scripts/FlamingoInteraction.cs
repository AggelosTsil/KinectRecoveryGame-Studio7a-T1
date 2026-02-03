using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamingoInteraction : MonoBehaviour
{
    private CubeGestureListener gestureListener;
    public PowerBarUI powerBar;
    public Player player;
    public KinectManager kinectManager;
    public Flamingo flamingo;
    // Start is called before the first frame update
    void Start()
    {
        //gestureListener = CubeGestureListener.Instance; //I am not sure how instances work

    }

    // Update is called once per frame
    void Update()
    {
        if (player.PowerReady){
            if (Punch(GetLeftHandPos())) //if punched with left hand
            {
                Debug.Log("punch LEFT"); //after player punches 
                player.UsePower("LEFT"); 
            }
            else if (Punch(GetRightHandPos())) //if punched with right hand
            {
                Debug.Log("punch RIGHT");
                player.UsePower("RIGHT");
            }
        }
    }
    public Transform GetRightHandPos()
    {
        Debug.Log("RightHand get");
        return transform.Find("HandRightCollider");
        
    }

    public Transform GetLeftHandPos()
    {
        Transform s = transform.Find("HandLeftCollider");
        Debug.Log("leftHand get" + s);
        return transform.Find("HandLeftCollider");
    }

    public Transform GetTorsoPos()
    {
        Debug.Log("spine get");
        return transform.Find("SpineShoulderCollider");
    }

    public bool Punch (Transform HandPos)
    {
        Debug.Log("punch distance is " + Vector3.Distance(HandPos.position, GetTorsoPos().position));
        if (Vector3.Distance(HandPos.position, GetTorsoPos().position) > 2)
        {
            Debug.Log("<Color=red>punched</color>");
            return true;
        }
        return false;
    }
}
