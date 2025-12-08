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

    //public int expectingRep;

    public int NumberOfReps;

    public int NumberOfErrors;

    //TO USE REPSTEP MANAGER MAKE SURE POSE DETECTOR HAS 0 SET IN DELAY AND 0 SET IN TIME-BETWEEN-CHECKS
    
    // Start is called before the first frame update
    void Start()
    {
        repstep = 0;
        //expectingRep = 1;
        NumberOfReps = 0;
        NumberOfErrors = 0;
        pose.poseModel = RepSteps[repstep];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (pose.IsPoseMatched())
        {
            Debug.Log("Step "+ repstep + " done. Inside Rep " + NumberOfReps);
            
            if (repstep < RepSteps.Length -1)
            {
                Debug.Log("Moving to next step");
                repstep ++;
                pose.poseModel = RepSteps[repstep];
                Debug.Log("Pose model is "+ RepSteps[repstep]);
            }
            else
            {
                Debug.Log("Rep completed");
                NumberOfReps++;
                repstep = 0;
                pose.poseModel = RepSteps[repstep];
                Debug.Log("Pose model is "+ RepSteps[repstep]);
            }
            
        }
    }

}
