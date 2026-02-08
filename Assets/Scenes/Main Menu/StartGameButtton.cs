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
        if (DataManager.instance.CurrentGameIndex >= DataManager.instance.CurrentPlaylist.Count)
        {
            SceneManager.LoadScene("MenuScene");
            return;
        }

        string sceneName = DataManager.instance.CurrentPlaylist[DataManager.instance.CurrentGameIndex].sceneName;
        SceneManager.LoadScene(sceneName);
    }
}
