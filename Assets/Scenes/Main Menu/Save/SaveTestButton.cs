using System.Collections.Generic;
using UnityEngine;

public class SaveTestButton : MonoBehaviour
{
    public List<Patient> AllPatients;
    public List<Game> AllGames; // not used here but nice for inspector

   public void SaveNow()
{
    List<PatientSaveData> saves =
        new List<PatientSaveData>();

    foreach (var go in DataManager.instance.AllPatients)
    {
        Patient p = go.GetComponent<Patient>();

        saves.Add(PatientSaveConverter.ToSave(p));
    }

    PatientSaveSystem.Save(saves);

    Debug.Log("Saved patients count = " + saves.Count);
}

}
