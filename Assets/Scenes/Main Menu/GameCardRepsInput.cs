using TMPro;
using UnityEngine;

public class GameCardRepsInput : MonoBehaviour
{
    public GameCard gameCard;
    TMP_InputField input;

    void Awake()
    {
        input = GetComponent<TMP_InputField>();
        input.onEndEdit.AddListener(OnRepsChanged);
    }

    void OnRepsChanged(string value)
    {
        int reps = 0;
        int.TryParse(value, out reps);

        gameCard.sessionData.Reps = reps;

        DataManager.instance.SaveAllPatients();
    }
}
