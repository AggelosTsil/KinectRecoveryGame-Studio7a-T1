using TMPro;
using UnityEngine;

public class LoadPatient : MonoBehaviour
{
    public Transform GameCardParent;     
    public GameObject GameCardPrefab;    

    public void LoadPatientData(GameObject patientGO)
    {
        Patient patient = patientGO.GetComponent<Patient>();
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = patientGO.name;
        DataManager.instance.CurrentPatient = patient;
        ClearGameCards();
        SpawnPlaylist(patient);
    }

    void ClearGameCards()
    {
        foreach (Transform child in GameCardParent)
        {
            Destroy(child.gameObject);
        }
    }

    void SpawnPlaylist(Patient patient)
    {
        foreach (GameSession session in patient.GamePlaylist)
        {
            GameObject cardGO = Instantiate(GameCardPrefab, GameCardParent);

            GameCard card = cardGO.GetComponent<GameCard>();
            card.Game = session.GamePrefab.gameObject;

            // reuse session data
            card.sessionData = session;

        }
    }
}
