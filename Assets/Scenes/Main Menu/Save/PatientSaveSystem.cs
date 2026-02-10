using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class PatientSaveSystem
{
    static string SavePath => Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Save") + "/patients.json";


    public static void Save(List<PatientSaveData> patients)
    {
        string directory = Path.GetDirectoryName(SavePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            Debug.Log(directory + " directory created");
        }

        PatientSaveWrapper wrapper = new PatientSaveWrapper();
        wrapper.Patients = patients;

        string json = JsonUtility.ToJson(wrapper, true);

        File.WriteAllText(SavePath, json);

        Debug.Log("Saved Patients → " + SavePath);
    }


    public static List<PatientSaveData> Load()
    {
        if (!File.Exists(SavePath))
            return new List<PatientSaveData>();

        string json = File.ReadAllText(SavePath);

        PatientSaveWrapper wrapper =
            JsonUtility.FromJson<PatientSaveWrapper>(json);

        return wrapper.Patients;
    }
}
