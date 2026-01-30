using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;

public class RepStepsManager : MonoBehaviour
{
    public PoseDetectorScript pose;

    public PoseModelHelper[] RepSteps;

    public int repstep;
    public Player player;

    //public int expectingRep;

    public int NumberOfReps;

    public int NumberOfErrors;

    public float PoseTime;

    public float timer; //osi wra exei meinei sto rep malaka voosten gamw

    public bool RestartRepOnFail; //if true it restarts the rep time every time there's an error

    public float TempErrorTime; //time of error

    public float MercyTime; //time before timer runs out that is ok to be out of pose

    //TO USE REPSTEP MANAGER MAKE SURE POSE DETECTOR HAS 0 SET IN DELAY AND 0 SET IN TIME-BETWEEN-CHECKS
    
    // Start is called before the first frame update
    void Start()
    {
        repstep = 0;
        //expectingRep = 1;
        NumberOfReps = 0;
        NumberOfErrors = 0;
        pose.poseModel = RepSteps[repstep];
        timer = PoseTime;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (pose.IsPoseMatched())
        {
            player.SetPower(Time.deltaTime);
            Debug.Log("Step "+ repstep + " done. Inside Rep " + NumberOfReps);
            timer -= Time.deltaTime;
            TempErrorTime = 0;
            
            if (repstep < RepSteps.Length -1 && timer <= MercyTime)
            {

                //ErrorCatcher (RepTime, Pose)
                Debug.Log("Moving to next step");
                repstep ++;
                pose.poseModel = RepSteps[repstep];
                Debug.Log("Pose model is "+ RepSteps[repstep]);
                timer = PoseTime;
                TempErrorTime = 0;
            }
            else if (timer <= MercyTime)
            {
                Debug.Log("Rep completed");
                NumberOfReps++;
                repstep = 0;
                pose.poseModel = RepSteps[repstep];
                Debug.Log("Pose model is "+ RepSteps[repstep]);
                timer = PoseTime;
                TempErrorTime = 0;
            }
            
        }
        else if (timer != PoseTime || timer >= PoseTime + MercyTime) 
        {
            player.SetPower(-Time.deltaTime);
            if (RestartRepOnFail){
                Debug.Log("Error kai kala " +  timer + " seconds in");
                timer = PoseTime;
                NumberOfErrors++;
                string filename = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
                ScreenCapture.CaptureScreenshot(filename);
            }
            else{
                if(TempErrorTime!= timer){
                    Debug.Log("Error kai kala " + timer + " seconds in");
                    TempErrorTime = timer;
                    NumberOfErrors++;
                    string filename = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
                    ScreenCapture.CaptureScreenshot(filename);
                }else
                    Debug.Log("Same error at " + timer);
            }
            
        }
        /*
        OLD Version:
        else if (timer != PoseTime) 
        {
            Debug.Log("Error kai kala " +  timer + " seconds in");
            timer = PoseTime;
            NumberOfErrors++;
        }
        */
    }

}
