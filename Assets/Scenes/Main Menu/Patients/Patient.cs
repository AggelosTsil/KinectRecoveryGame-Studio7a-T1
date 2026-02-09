using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSession
{
    public Game GamePrefab;
    public float durationSeconds;
    public int SelectedThemeIndex;

}

public class Patient : MonoBehaviour
{
    #region Patient
    [Header("Patient")]
   public String Name;
   public String Surname;
   public String Number;
   public String email;
   #endregion
   
    #region Doctor
    [Header("Doctor")]
   public String Name_Doctor;
   public String Surname_Doctor;
   public String Number_Doctor;
   public String email_Doctor;
   #endregion 
    
    #region Diagnosis
    [Header("Diagnosis")]
   public String Diagnosis;
   public String Notes;
   public int Sessions;
   #endregion
   #region Game Playlist
[Header("Game Playlist")]
public List<GameSession> GamePlaylist = new List<GameSession>();
#endregion


 

}
