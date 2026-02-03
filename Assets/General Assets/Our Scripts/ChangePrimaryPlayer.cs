using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Numerics;
using UnityEditor.PackageManager.UI;
using UnityEngine.iOS;
using Unity.VisualScripting;

[RequireComponent(typeof(CubeGestureListener))]
public class ChangePrimaryPlayer : MonoBehaviour
{
    public AvatarController avatarController;
    public GameObject MainPlayerIndicatorSTAR;
    public float offset;
    Body mainBody = null; 
    private KinectSensor sensor;
    private BodyFrameReader bodyReader;
    private Body[] bodies;
    private List<ulong> trackedPlayerIds = new List<ulong>();
    private int mainPlayerIndex = 0;
    public Camera kinectCamera;
    public ulong MainPlayerId {get; private set;}
    // Start is called before the first frame update
    void Start()
    {
      sensor = KinectSensor.GetDefault();
      bodyReader = sensor.BodyFrameSource.OpenReader();
      bodies = new Body[sensor.BodyFrameSource.BodyCount];
      if (!sensor.IsOpen)
        {
           sensor.Open(); //not sure what that does I believe its a failsafe. Either way I think we are ok without it
        }
    }

    // Update is called once per frame
    void Update()
    {
        using (BodyFrame frame = bodyReader.AcquireLatestFrame())
        {
            if (frame == null) return;
            frame.GetAndRefreshBodyData(bodies);
            trackedPlayerIds.Clear();

            foreach (Body body in bodies)
            {
                if (body != null && body.IsTracked)
                {
                    trackedPlayerIds.Add(body.TrackingId);
                }
            }
            if (trackedPlayerIds.Count > 0)
            {
                mainPlayerIndex = Mathf.Clamp(mainPlayerIndex, 0, trackedPlayerIds.Count - 1);
                MainPlayerId = trackedPlayerIds[mainPlayerIndex];
            }
        }
    }
    public void SwitchMainPlayer(InputAction.CallbackContext context) // callbackcontext is so that we can change the controls from the InputAction System. DONT TOUCH THIS SHIT
    {
        if (trackedPlayerIds.Count == 0) return;

        mainPlayerIndex = (mainPlayerIndex + 1) % trackedPlayerIds.Count;
        MainPlayerId = trackedPlayerIds[mainPlayerIndex];

        avatarController.playerIndex = mainPlayerIndex;
        Debug.Log("Main player is now TrackingId:" + MainPlayerId);
        PlayerAnimation(MainPlayerId); //plays little animation over players head
        ChangeGestureListener(mainPlayerIndex); //Changes gesture listener to new main player
    }

    public void PlayerAnimation(ulong ID)
    {
        foreach (Body body in bodies)
        {
            if (body.TrackingId == ID)
            {
                GameObject Indicator = Instantiate(MainPlayerIndicatorSTAR,GetHeadPos(), UnityEngine.Quaternion.identity );//creates the little star, has to change to picking from a list or just changes in the editor
                //Indicator.transform.position = worldPosition;
                Debug.Log("indicator spawned at " + GetHeadPos());
                return;
            
            }
        }
    }

    public void ChangeGestureListener(int index) //Makes sure the gestures listener stays on the main player
    {
        GetComponent<CubeGestureListener>().playerIndex = index;
    }

    public UnityEngine.Vector3 GetHeadPos()
    {
        Transform headT = transform.Find("HeadCollider");
        return new UnityEngine.Vector3(headT.position.x, headT.position.y, headT.position.z - 1);
    }
}
