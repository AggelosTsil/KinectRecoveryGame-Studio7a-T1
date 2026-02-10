using TMPro;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    public GameObject Game;
    public GameSession sessionData;
    public MinutesToSeconds minutesScript;
    public MinutesToSeconds secondsScript;

    void Start()
    {
        transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = Game.GetComponent<Game>().name;
        SetupSession();
        LoadExistingTime();
    }

    void SetupSession()
    {
        if (sessionData == null)
            sessionData = new GameSession();

        sessionData.GamePrefab = Game.GetComponent<Game>();


        if (minutesScript != null)
            minutesScript.gameSession = sessionData;

        if (secondsScript != null)
            secondsScript.gameSession = sessionData;
    }

    void LoadExistingTime()
    {
        if (sessionData == null) return;

        int minutes = Mathf.FloorToInt(sessionData.durationSeconds / 60f);
        int seconds = Mathf.FloorToInt(sessionData.durationSeconds % 60f);

        if (minutesScript != null)
            minutesScript.GetComponent<TMP_InputField>().text =
                minutes.ToString("00");

        if (secondsScript != null)
            secondsScript.GetComponent<TMP_InputField>().text =
                seconds.ToString("00");
    }

}
