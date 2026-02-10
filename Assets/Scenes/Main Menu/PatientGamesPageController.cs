using System.Collections.Generic;
using UnityEngine;

public class PatientGamesPageController : MonoBehaviour
{
    [Header("Containers")]
    public Transform AvailableGamesContainer;
    public Transform PlaylistContainer;

    [Header("Prefabs")]
    public GameObject AvailableGameButtonPrefab;
    public GameObject PlaylistGameButtonPrefab;

    Patient CurrentPatient;

    void OnEnable()
    {
        CurrentPatient = DataManager.instance.CurrentPatient;

        RefreshUI();
    }

    // BUILD BOTH LISTS
    public void RefreshUI()
    {
        ClearContainer(AvailableGamesContainer);
        ClearContainer(PlaylistContainer);

        SpawnAvailableGames();
        SpawnPlaylist();
    }

    void ClearContainer(Transform parent)
    {
        foreach (Transform child in parent)
            Destroy(child.gameObject);
    }

    // LEFT SIDE
    void SpawnAvailableGames()
    {
        foreach (var game in DataManager.instance.AllGames)
        {
            var btn = Instantiate(AvailableGameButtonPrefab, AvailableGamesContainer);
            btn.GetComponent<AvailableGameButton>().Setup(game, this);
        }
    }

    // RIGHT SIDE
    void SpawnPlaylist()
    {
        foreach (var session in CurrentPatient.GamePlaylist)
        {
            var btn = Instantiate(PlaylistGameButtonPrefab, PlaylistContainer);
            btn.GetComponent<PlaylistGameButton>().Setup(session, this);
        }
    }

 
    // ADD GAME
    public void AddGame(Game game)
    {
        GameSession newSession = new GameSession();
        newSession.GamePrefab = game;
        newSession.durationSeconds = 0;
        newSession.Reps = 0;
        newSession.Difficulty = 1;

        CurrentPatient.GamePlaylist.Add(newSession);

        DataManager.instance.SaveAllPatients();

        RefreshUI();
    }

    // REMOVE GAME
    public void RemoveSession(GameSession session)
    {
        CurrentPatient.GamePlaylist.Remove(session);

        DataManager.instance.SaveAllPatients();

        RefreshUI();
    }
}
