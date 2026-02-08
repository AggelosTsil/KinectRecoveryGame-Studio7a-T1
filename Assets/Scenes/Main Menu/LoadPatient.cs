using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadPatient : MonoBehaviour
{
    
    public void LoadPatientData(GameObject Patient)
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Patient.name;
    }
}
