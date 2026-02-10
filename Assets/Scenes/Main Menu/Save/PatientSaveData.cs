using System.Collections.Generic;

[System.Serializable]
public class PatientSaveData
{
    public string Name;
    public string Surname;
    public string Number;
    public string Email;
    public string DoctorName;
    public string DoctorSurname;
    public string DoctorNumber;
    public string DoctorEmail;
    public string Diagnosis;
    public string Notes;
    public int Sessions;

    public List<GameSessionSaveData> Playlist = new List<GameSessionSaveData>();

}
