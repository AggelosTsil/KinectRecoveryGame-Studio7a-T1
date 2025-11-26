using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreRightText;
    public CanScore CanRight;

    public Text ScoreLeftText;

    public CanScore CanLeft;

    int ScoreRight;

    int ScoreLeft;

    // Start is called before the first frame update
    void Start()
    {
        int ScoreRight = CanRight.score;
        ScoreRightText.text = "Right Points " + ScoreRight.ToString();

        int ScoreLeft = CanLeft.score;
        ScoreLeftText.text = "Left Points " + ScoreLeft.ToString();

    }

    public void AddPoint(String CanID)
    {
        switch (CanID) 
        {
            case "Right":
            ScoreRight++;
            ScoreRightText.text = "Right Points " + ScoreRight.ToString();
            break;

            case "Left":
            ScoreLeft++;
            ScoreLeftText.text = "Left Points " + ScoreLeft.ToString();
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
