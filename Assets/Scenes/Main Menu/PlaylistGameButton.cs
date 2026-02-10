using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlaylistGameButton : MonoBehaviour
{
    GameSession session;
    PatientGamesPageController controller;

    public TMP_Text label;
    public Button button;

    public void Setup(GameSession s, PatientGamesPageController c)
    {
        session = s;
        controller = c;

        label.text = s.GamePrefab.ExerciseName;

        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        controller.RemoveSession(session);
    }
}
