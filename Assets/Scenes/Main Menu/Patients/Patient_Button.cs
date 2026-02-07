using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using System.Drawing;

public class Patient_Button : MonoBehaviour
{
   public GameObject Patient;
   public int Sessions;
   public LoadPatient LoadPatient;


   public GameObject[] OffStuff;
   public GameObject[] OnStuff;   

    public void Update()
    {
        TextMeshProUGUI Button_Sessions = transform.GetChild(2).transform.GetComponent<TextMeshProUGUI>();
        Sessions = Patient.GetComponent<Patient>().Sessions;
        Button_Sessions.text = Sessions.ToString();
    }

    public void OnClick()
    {
        for (int i = 0; i < OffStuff.Length; i++ )
        {
            OffStuff[i].SetActive(false);
        }
        for (int i = 0; i < OnStuff.Length; i++ )
        {
            OnStuff[i].SetActive(true);
        }
        LoadPatient.LoadPatientData(Patient);
    }
}
