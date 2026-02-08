using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButtton : MonoBehaviour
{
    public SceneAsset Scene;
    private Button button;
    public Patient selectedPatient;
    public void Awake()
    {
        button = this.GetComponent<Button>();
    }
    void Update()
    {
        if (DataManager.instance.TransportValue == 0)
        {
            button.interactable = false;
        }else button.interactable = true;
    }
    public void LoadScene()
    {
        DataManager.instance.CurrentPatient = selectedPatient;
        DataManager.instance.CurrentPlaylist = selectedPatient.GamePlaylist;
        DataManager.instance.CurrentGameIndex = 0;

        LoadNextScene();
    }
   public static void LoadNextScene()
{
    DataManager dm = DataManager.instance;
    if (dm == null)
    {
        Debug.LogError("DataManager missing!");
        return;
    }
    if (dm.CurrentGameIndex >= dm.CurrentPlaylist.Count)
    {
        Debug.Log("Playlist finished → Loading Menu");
        SceneManager.LoadScene("MenuScene");
        return;
    }

    GameSession currentSession = dm.CurrentPlaylist[dm.CurrentGameIndex];

    if (currentSession == null)
    {
        Debug.LogError("GameSession is NULL");
        return;
    }

    if (currentSession.GamePrefab == null)
    {
        Debug.LogError("GamePrefab is NULL");
        return;
    }

    Game gameData = currentSession.GamePrefab;

    if (string.IsNullOrEmpty(gameData.SceneName))
    {
        Debug.LogError("SceneName is EMPTY on Game Prefab");
        return;
    }

    dm.CurrentSceneDuration = currentSession.durationSeconds;

    Debug.Log( "Loading Scene: " + gameData.SceneName + " | Duration: " + dm.CurrentSceneDuration);

    
    SceneManager.LoadScene(gameData.SceneName);
}

}
