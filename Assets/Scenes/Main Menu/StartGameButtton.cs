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
        SceneManager.LoadScene(Scene.name);
    }
}
