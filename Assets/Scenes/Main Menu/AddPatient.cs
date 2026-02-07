using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

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

    #region requirements
    public GameObject Patient;
    public GameObject AllPatients;
    #endregion
   public void OnClick()
    {
        AddPatientMethod(Name.text,Surname.text,Number.text,email.text,
        Name_Doctor.text,Surname_Doctor.text,Number_Doctor.text,email_Doctor.text,
        Diagnosis.text,Notes.text);
    }

    public void AddPatientMethod(String Name, String Surname, String Number, String email, String Name_Doctor,
   String Surname_Doctor, String Number_Doctor, String email_Doctor, String Diagnosis, String Notes)
    {
        var newPatient = Instantiate (Patient, AllPatients.transform);
        var PatientData = newPatient.GetComponent<Patient>();
        if (Name == "")
        {
            Name = "-";
        }
        newPatient.name = Name + Surname;

        PatientData.Name = Name;
        PatientData.Surname = Surname;
        PatientData.Number = Number;
        PatientData.email = email;
        PatientData.Name_Doctor = Name_Doctor;
        PatientData.Surname_Doctor = Surname_Doctor;
        PatientData.Number_Doctor = Number_Doctor;
        PatientData.email_Doctor = email_Doctor;
        PatientData.Diagnosis = Diagnosis;
        PatientData.Notes = Notes;
    }
   
}
