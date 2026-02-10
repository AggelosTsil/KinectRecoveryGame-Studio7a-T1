using System.Collections.Generic;

[System.Serializable]
public class PatientSaveData
{
    // ===== PATIENT =====
    public string Name;
    public string Surname;
    public string Number;
    public string Email;

    // ===== DOCTOR =====
    public string DoctorName;
    public string DoctorSurname;
    public string DoctorNumber;
    public string DoctorEmail;

    // ===== MEDICAL =====
    public string Diagnosis;
    public string Notes;
    public int Sessions;

    // ===== THERAPY CONFIG =====
    public List<GameSessionSaveData> Playlist =
        new List<GameSessionSaveData>();

    // ===== FUTURE HISTORY =====
    public List<SessionHistorySaveData> History =
        new List<SessionHistorySaveData>();
}
