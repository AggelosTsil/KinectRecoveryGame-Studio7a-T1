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
        Debug.LogError("DataManager missing");
        return;
    }

    if (dm.CurrentGameIndex >= dm.CurrentPlaylist.Count)
    {
        Debug.Log("Playlist Finished → Menu");

        if (dm.CurrentPatient != null)
            dm.CurrentPatient.Sessions++;

        SceneManager.LoadScene("MenuScene");
        return;
    }

    GameSession session =
        dm.CurrentPlaylist[dm.CurrentGameIndex];

    if (session == null || session.GamePrefab == null)
    {
        Debug.LogError("Invalid Session");
        return;
    }

    Game game = session.GamePrefab;

    if (game.ThemesList == null ||
        game.ThemesList.Count == 0)
    {
        Debug.LogError("Game has no themes");
        return;
    }

    // ⭐ If using reorder logic
    Themes theme = game.ThemesList[0];

    Debug.Log("Loading Theme Scene → " + theme.SceneName);

    dm.CurrentSceneDuration =
        session.durationSeconds;

    SceneManager.LoadScene(theme.SceneName);
}

}
