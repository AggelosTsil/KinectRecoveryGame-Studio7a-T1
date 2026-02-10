using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PatientEditPage : MonoBehaviour
{
    [Header("Patient Fields")]
    public TMP_InputField Name;
    public TMP_InputField Surname;
    public TMP_InputField Number;
    public TMP_InputField Email;

    [Header("Doctor Fields")]
    public TMP_InputField DoctorName;
    public TMP_InputField DoctorSurname;
    public TMP_InputField DoctorNumber;
    public TMP_InputField DoctorEmail;

    [Header("Diagnosis")]
    public TMP_InputField Diagnosis;
    public TMP_InputField Notes;

    [Header("Navigation")]
    public GameObject PlaylistPage;
    public GameObject PatientListPage;

    Patient CurrentPatient;

    //Load
    public void OpenForPatient(Patient patient)
{
    DataManager.instance.CurrentPatient = patient;

    gameObject.SetActive(true);

    LoadCurrentPatient(); // force load immediately
}


    void LoadCurrentPatient()
    {
        Debug.Log("Loading Patient: " +
    DataManager.instance.CurrentPatient);

        CurrentPatient = DataManager.instance.CurrentPatient;

        if (CurrentPatient == null) return;

        Name.text = CurrentPatient.Name;
        Surname.text = CurrentPatient.Surname;
        Number.text = CurrentPatient.Number;
        Email.text = CurrentPatient.email;

        DoctorName.text = CurrentPatient.Name_Doctor;
        DoctorSurname.text = CurrentPatient.Surname_Doctor;
        DoctorNumber.text = CurrentPatient.Number_Doctor;
        DoctorEmail.text = CurrentPatient.email_Doctor;

        Diagnosis.text = CurrentPatient.Diagnosis;
        Notes.text = CurrentPatient.Notes;
    }

    //Edit
    public void SaveEdits()
    {
        if (CurrentPatient == null) return;

        CurrentPatient.Name = Name.text;
        CurrentPatient.Surname = Surname.text;
        CurrentPatient.Number = Number.text;
        CurrentPatient.email = Email.text;

        CurrentPatient.Name_Doctor = DoctorName.text;
        CurrentPatient.Surname_Doctor = DoctorSurname.text;
        CurrentPatient.Number_Doctor = DoctorNumber.text;
        CurrentPatient.email_Doctor = DoctorEmail.text;

        CurrentPatient.Diagnosis = Diagnosis.text;
        CurrentPatient.Notes = Notes.text;

        DataManager.instance.SaveAllPatients();

        Debug.Log("Patient Updated + Saved");
    }

   //Delete
    public void DeletePatient()
    {
       

        DataManager.instance.AllPatients.Remove(
            CurrentPatient.gameObject);

        Destroy(CurrentPatient.gameObject);

        DataManager.instance.SaveAllPatients();

        
        Debug.Log("Patient Deleted");
    }

    //StartSession
    public void StartSession()
    {
        if (CurrentPatient == null) return;

        PlaylistPage.SetActive(true);
        gameObject.SetActive(false);
        PlaylistPage.GetComponent<LoadPatient>().LoadPatientData(DataManager.instance.CurrentPatient.gameObject);

    }
}
