using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButtton : MonoBehaviour
{
    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }

   void Update()
{
    Patient patient = DataManager.instance.CurrentPatient;

    if (patient == null || patient.GamePlaylist == null)
    {
        button.interactable = false;
        return;
    }

    // Enable only if at least one game has time > 0
    bool hasValidGame = false;

    foreach (var session in patient.GamePlaylist)
    {
        if (session != null &&
            session.GamePrefab != null &&
            session.durationSeconds > 0)
        {
            hasValidGame = true;
            break;
        }
    }

    button.interactable = hasValidGame;
}

    // ========================
    // START SESSION
    // ========================
    public void StartGame()
    {
        StartPlaylist(DataManager.instance.CurrentPatient);
    }

    // ========================
    // START PLAYLIST SESSION
    // ========================
    public static void StartPlaylist(Patient patient)
    {
        DataManager dm = DataManager.instance;

        if (patient == null)
        {
            Debug.LogError("StartPlaylist → Patient NULL");
            return;
        }

        if (patient.GamePlaylist == null || patient.GamePlaylist.Count == 0)
        {
            Debug.LogError("StartPlaylist → Empty Playlist");
            return;
        }

        // Save runtime patient
        dm.CurrentPatient = patient;

        // Copy playlist (IMPORTANT → not reference)
        dm.CurrentPlaylist = new List<GameSession>();

        foreach (var session in patient.GamePlaylist)
        {
            dm.CurrentPlaylist.Add(new GameSession()
            {
                GamePrefab = session.GamePrefab,
                durationSeconds = session.durationSeconds
            });
        }

        dm.CurrentGameIndex = 0;

        Debug.Log("Session Started → Games: " + dm.CurrentPlaylist.Count);
        DontDestroyOnLoad(patient.gameObject);


        LoadNextScene();
    }

    // ========================
    // LOAD NEXT SCENE
    // ========================
    public static void LoadNextScene()
    {
        DataManager dm = DataManager.instance;

        if (dm == null)
        {
            Debug.LogError("DataManager missing!");
            return;
        }

        // End of playlist → Return menu
        if (dm.CurrentGameIndex >= dm.CurrentPlaylist.Count)
        {
            Debug.Log("Playlist finished → Loading Menu");
            SceneManager.LoadScene("MainMenu");
            return;
        }

        GameSession currentSession = dm.CurrentPlaylist[dm.CurrentGameIndex];

        if (currentSession == null || currentSession.GamePrefab == null)
        {
            Debug.LogError("Invalid GameSession!");
            return;
        }

        Game gameData = currentSession.GamePrefab;

        if (string.IsNullOrEmpty(gameData.SceneName))
        {
            Debug.LogError("SceneName missing on Game Prefab");
            return;
        }

        // Save runtime duration
        dm.CurrentSceneDuration = currentSession.durationSeconds;

        Debug.Log($"Loading Scene → {gameData.SceneName} | Time → {dm.CurrentSceneDuration}");

        SceneManager.LoadScene(gameData.SceneName);
    }
}
