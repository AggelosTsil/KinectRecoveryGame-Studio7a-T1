using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;



    // =============================
    // ALL PATIENTS (SAVE SOURCE)
    // =============================
    public List<GameObject> AllPatients =
        new List<GameObject>();

    // =============================
    // GAME DATABASE (FOR LOAD)
    // =============================
    public List<Game> AllGames =
        new List<Game>();
    public GameObject PatientPrefab;
    public Transform PatientsParent;

    // =============================
    // RUNTIME SESSION DATA
    // =============================
    public Patient CurrentPatient;
    public List<GameSession> CurrentPlaylist =
        new List<GameSession>();
    public int CurrentGameIndex;
    public float CurrentSceneDuration;

    // =============================
    // SINGLETON SETUP
    // =============================
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

   void OnEnable()
{
    SceneManager.sceneLoaded += OnSceneLoaded;
}

void OnDisable()
{
    SceneManager.sceneLoaded -= OnSceneLoaded;
}

void OnSceneLoaded(Scene scene, LoadSceneMode mode)
{
    if (scene.name == "MainMenu")
    {
        FindSceneReferences();
        ReloadPatientsFromSave();
    }
}
public void FindSceneReferences()
{
    if (PatientsParent == null)
    {
        GameObject parent =
            GameObject.Find("AllPatients");

        if (parent != null)
            PatientsParent = parent.transform;
        else
            Debug.LogError("AllPatients parent not found!");
    }
}

    public void ReloadPatientsFromSave()
{
    AllPatients.Clear();
    LoadAllPatients();
    PatientsParent = GameObject.Find("AllPatients").transform;

}


    public void LoadAllPatients()
    {
        Debug.Log("Loading Patients...");

        List<PatientSaveData> saves =
            PatientSaveSystem.Load();

        Debug.Log("Save File Patients = " + saves.Count);

        foreach (var save in saves)
        {
            // Create Patient GameObject
            GameObject go =
                Instantiate(PatientPrefab, PatientsParent);

            Patient patient =
                go.GetComponent<Patient>();

            // Apply saved data
            PatientSaveConverter.ApplySaveToPatient(
                patient,
                save,
                AllGames);

            // Add to runtime list
            AllPatients.Add(go);

            Debug.Log("Loaded Patient → " + patient.Name);
        }
    }

    public void SaveAllPatients()
    {
         List<PatientSaveData> saves =
        new List<PatientSaveData>();

    foreach (var go in AllPatients)
    {
        if (go == null) continue;

        Patient p = go.GetComponent<Patient>();

        if (p == null) continue;

        saves.Add(PatientSaveConverter.ToSave(p));
    }

    PatientSaveSystem.Save(saves);

    Debug.Log("AUTOSAVE COMPLETE → Patients = " + saves.Count);
    }

}
