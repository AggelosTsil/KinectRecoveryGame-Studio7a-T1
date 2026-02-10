using System.Diagnostics;
using TMPro;
using UnityEngine;

public class GameCardDifficultyDropdown : MonoBehaviour
{
    public GameCard gameCard;
    TMP_Dropdown dropdown;

    void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.onValueChanged.AddListener(OnDifficultyChanged);
    }

    void OnDifficultyChanged(int index)
    {
        float difficultyValue = 0;
        switch(index){
            case 0:
            difficultyValue = 0.8f;
            break;
            case 1:
            difficultyValue = 0.8f;
            break;
            case 2:
            difficultyValue = 0.8f;
            break;
        }

        gameCard.sessionData.Difficulty = difficultyValue;

        DataManager.instance.SaveAllPatients();
    }
}
