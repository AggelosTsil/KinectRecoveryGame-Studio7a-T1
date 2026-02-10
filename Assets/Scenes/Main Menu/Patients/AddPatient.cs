using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AddPatient : MonoBehaviour
{
        #region Patient
    [Header("Patient")]
   public TMP_InputField Name;
   public TMP_InputField Surname;
   public TMP_InputField Number;
   public TMP_InputField email;
   #endregion
   
    #region Doctor
    [Header("Doctor")]
   public TMP_InputField Name_Doctor;
   public TMP_InputField Surname_Doctor;
   public TMP_InputField Number_Doctor;
   public TMP_InputField email_Doctor;
   #endregion 
    
    #region Diagnosis
    [Header("Diagnosis")]
   public TMP_InputField Diagnosis;
   public TMP_InputField Notes;
   #endregion
   [Header("Default Playlist")]
    public List<GameSession> DefaultPlaylist = new List<GameSession>();


    #region requirements
    [Header("Requirements")]
    public GameObject Patient;
    public GameObject Button;
    public GameObject AllPatients;
    public GameObject ButtonList;
    [Header("Stuff for the Patient Button To Inherit")]
    public LoadPatient LoadPatient;
    public GameObject[] OffStuff;
    public GameObject[] OnStuff;
    #endregion
   public void OnClick()
    {
        AddPatientMethod(Name.text,Surname.text,Number.text,email.text,
        Name_Doctor.text,Surname_Doctor.text,Number_Doctor.text,email_Doctor.text,
        Diagnosis.text,Notes.text);
    }

    public void AddPatientMethod(
    string Name,
    string Surname,
    string Number,
    string email,
    string Name_Doctor,
    string Surname_Doctor,
    string Number_Doctor,
    string email_Doctor,
    string Diagnosis,
    string Notes)
{
    var newPatient =
        Instantiate(Patient, AllPatients.transform);

    var PatientData =
        newPatient.GetComponent<Patient>();

    if (Name == "")
        Name = "-";

    newPatient.name = Name + " " + Surname;

    // ===== PATIENT DATA =====
    PatientData.Name = Name;
    PatientData.Surname = Surname;
    PatientData.Number = Number;
    PatientData.email = email;

    // ===== DOCTOR =====
    PatientData.Name_Doctor = Name_Doctor;
    PatientData.Surname_Doctor = Surname_Doctor;
    PatientData.Number_Doctor = Number_Doctor;
    PatientData.email_Doctor = email_Doctor;

    // ===== MEDICAL =====
    PatientData.Diagnosis = Diagnosis;
    PatientData.Notes = Notes;
    PatientData.Sessions = 0;

    // ===== DEFAULT PLAYLIST =====
    PatientData.GamePlaylist = new List<GameSession>();

    foreach (var templateSession in DefaultPlaylist)
    {
        PatientData.GamePlaylist.Add(new GameSession()
        {
            GamePrefab = templateSession.GamePrefab,
            durationSeconds = templateSession.durationSeconds
        });
    }

    // ===== REGISTER IN DATAMANAGER =====
    DataManager.instance.AllPatients.Add(newPatient);
    DataManager.instance.SaveAllPatients();

}

   
}
