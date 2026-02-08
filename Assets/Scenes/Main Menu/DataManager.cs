using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private float transportvalue;
    public float TransportValue { get => transportvalue; set => transportvalue = value; }
    public static DataManager instance;
    public Patient CurrentPatient;
    public List<GameSession> CurrentPlaylist = new List<GameSession>();
    public int CurrentGameIndex = 0;
    public float CurrentSceneDuration;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

   
}
