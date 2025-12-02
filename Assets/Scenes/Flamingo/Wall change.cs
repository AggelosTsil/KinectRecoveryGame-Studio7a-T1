using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Wallchange : MonoBehaviour
{
    public PoseDetectorScript pose;
    public Material Footdown;
    public Material Footup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
