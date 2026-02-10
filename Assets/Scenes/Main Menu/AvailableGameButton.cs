using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AvailableGameButton : MonoBehaviour
{
    Game game;
    PatientGamesPageController controller;

    public TMP_Text label;
    public Button button;

    public void Setup(Game g, PatientGamesPageController c)
    {
        game = g;
        controller = c;

        label.text = g.ExerciseName;

        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        controller.AddGame(game);
    }
}
