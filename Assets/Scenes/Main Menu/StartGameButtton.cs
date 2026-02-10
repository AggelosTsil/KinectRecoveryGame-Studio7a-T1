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
        // Enable only if patient and playlist exists
        var dm = DataManager.instance;

        if (dm == null || dm.CurrentPatient == null || dm.CurrentPatient.GamePlaylist == null || dm.CurrentPatient.GamePlaylist.Count == 0)
        {
            button.interactable = false;
            return;
        }

        bool allValid = true;

        foreach (var s in dm.CurrentPatient.GamePlaylist)
        {
            if (s == null || s.GamePrefab == null || s.durationSeconds <= 0)
            {
                allValid = false;
                break;
            }
        }

        button.interactable = allValid;

    }

    // START SESSION
    public void StartGame()
    {
        StartPlaylist(DataManager.instance.CurrentPatient);
        DataManager.instance.CurrentPatient.Sessions++;
        DataManager.instance.SaveAllPatients();
    }


    // COPY PATIENT PLAYLIST → RUNTIME PLAYLIST
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

        dm.CurrentPatient = patient;

        // Copy playlist 
        dm.CurrentPlaylist = new List<GameSession>();

        foreach (var s in patient.GamePlaylist)
        {
            GameSession runtime = new GameSession();

            runtime.GamePrefab = s.GamePrefab;
            runtime.SelectedThemeIndex = s.SelectedThemeIndex;
            runtime.durationSeconds = s.durationSeconds;

            dm.CurrentPlaylist.Add(runtime);
        }
        dm.CurrentGameIndex = 0;
        LoadNextScene();
    }

    // LOAD NEXT GAME SCENE 
    public static void LoadNextScene()
    {

        DataManager dm = DataManager.instance;
        if (dm == null)
        {
            Debug.LogError("LoadNextScene → DataManager missing");
            return;
        }

        // FINISHED 
        if (dm.CurrentGameIndex >= dm.CurrentPlaylist.Count)
        {
            Debug.Log("Playlist finished → Returning to Menu");
            SceneManager.LoadScene("MainMenu");

            return;
        }

        GameSession session = dm.CurrentPlaylist[dm.CurrentGameIndex];

        if (session == null || session.GamePrefab == null)
        {
            Debug.LogError("LoadNextScene → Invalid Session");
            return;
        }

        Game game = session.GamePrefab;

        if (game.ThemesList == null || game.ThemesList.Count == 0)
        {
            Debug.LogError("Game has no themes assigned!");
            return;
        }

        int themeIndex = session.SelectedThemeIndex;

        if (themeIndex < 0 || themeIndex >= game.ThemesList.Count)
        {
            Debug.LogWarning("Theme index invalid → Reset to 0");
            themeIndex = 0;
        }

        Themes selectedTheme = game.ThemesList[themeIndex];

        if (string.IsNullOrEmpty(selectedTheme.SceneName))
        {
            Debug.LogError("Selected theme has empty SceneName");
            return;
        }

        dm.CurrentSceneDuration = session.durationSeconds;

        Debug.Log($"Loading → Game:{game.ExerciseName} | " + $"Theme:{selectedTheme.ThemeName} | " + $"Scene:{selectedTheme.SceneName} | " + $"Duration:{dm.CurrentSceneDuration}");
        SceneManager.LoadScene(selectedTheme.SceneName);
    }
}
