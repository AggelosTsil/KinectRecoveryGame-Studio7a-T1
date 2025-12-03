using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootScript : MonoBehaviour
{
    public GameObject Foot;
    public GameObject Ankle;

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Find("Foot").transform.position = Foot.transform.position;
        this.transform.Find("Ankle").transform.position = Ankle.transform.position;
    }
}
