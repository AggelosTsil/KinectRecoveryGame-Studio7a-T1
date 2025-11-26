using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanScore : MonoBehaviour
{
    public int score;
    public String ID;

    public ScoreManager ScoreManager;
    // Start is called before the first frame update
    void Start()
    {
       //score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
       // if (collision.gameObject.CompareTag("Burger"))
      //  {
      //      ScoreManager.AddPoint(ID);
      //      UnityEngine.Debug.Log("Found a BURGER");
      //  }

        switch (collision.gameObject.tag)
        {
            case "Burger":
            ScoreManager.AddPoint(ID);
            UnityEngine.Debug.Log("Found a BURGER");
            break;
            default : 
            UnityEngine.Debug.Log("Collided with " + collision.gameObject.tag);
            break;
        }
    }
}
