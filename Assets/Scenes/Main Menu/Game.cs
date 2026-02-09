using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[System.Serializable]
public class Themes
{
    public String ThemeName;
    public String SceneName;
}
public class Game : MonoBehaviour
{
  public int Gameid;
  public String ExerciseName;
  public String SceneName;

  [Header ("Themes")]
  public List<Themes> ThemesList = new List<Themes>();

    void Update()
    {
        Gameid = transform.GetSiblingIndex();
        ExerciseName = this.name;
        SceneName = ThemesList[0].SceneName;
    }

    public void ChangeTheme()
  {
    
  }
}
