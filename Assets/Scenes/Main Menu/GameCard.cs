using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    public GameObject Game;

    void Update()
    {
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = Game.GetComponent<Game>().Name;
    }
}
