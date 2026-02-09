using TMPro;
using UnityEngine;

public class ChangeTheme : MonoBehaviour
{
    private TMP_Dropdown themeDropdown;
    public GameCard gameCard;   // ⭐ IMPORTANT
    void Awake()
    {
        themeDropdown = GetComponent<TMP_Dropdown>();
        gameCard = GetComponentInParent<GameCard>();
    }

    void Start()
    {
        SetupDropdown();
    }

    void SetupDropdown()
    {
        if (gameCard == null) return;
        Game game = gameCard.sessionData.GamePrefab;
        themeDropdown.ClearOptions();
        foreach (var theme in game.ThemesList)
        {
            themeDropdown.options.Add(
                new TMP_Dropdown.OptionData(theme.ThemeName));
        }
        themeDropdown.onValueChanged.AddListener(OnThemeChanged);
        // Load existing 
        themeDropdown.value = gameCard.sessionData.SelectedThemeIndex;
    }

    void OnThemeChanged(int index)
    {
        gameCard.sessionData.SelectedThemeIndex = index;
        Debug.Log("Theme changed → " + gameCard.sessionData.GamePrefab.ThemesList[index].ThemeName);
    }
}
