using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RepStepsManager : MonoBehaviour
{
    public PoseDetectorScript pose;

    public PoseModelHelper[] RepStep;

    public int repseq;

    public int expectingRep;

 
    // Start is called before the first frame update
    void Start()
    {
        repseq = 0;
        expectingRep = 1;
    }

    // Update is called once per frame
    void LateUpdate()
    {
     if (pose.IsPoseMatched())
        {
            repseq = CountRep(repseq, expectingRep);
            if (expectingRep <= RepStep.Length)
            {
                pose.poseModel = RepStep[repseq];
            }
            if (repseq >= RepStep.Length)
            {
                Debug.Log("REP COMPLETE!");
                repseq = 0;
                expectingRep = 1;
            }
            else expectingRep++;
          
        }   
    }

    int CountRep(int repseq, int expectingRep)
    {
        if (repseq < expectingRep)
        {
            repseq++;
            Debug.Log("DID STEP " + repseq);
        }
        return repseq;
    } 
}
