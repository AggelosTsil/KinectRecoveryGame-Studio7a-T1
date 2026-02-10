using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PatientButtonLoader : MonoBehaviour
{
    [Header("References")]
    public GameObject ButtonPrefab;
    public Transform ButtonListParent;
    public Transform PatientsParent;

    [Header("Button Dependencies")]
    public LoadPatient LoadPatient;
    public PatientEditPage patientEditPage;
    public GameObject[] OffStuff;
    public GameObject[] OnStuff;

    void OnEnable()
    {
        CreateButtons();
    }

    public void CreateButtons()
    {
        
       ClearButtons();

        foreach (Transform patientTransform in PatientsParent)
        {
            GameObject patientGO = patientTransform.gameObject;
            Patient patient = patientGO.GetComponent<Patient>();

            if (patient == null) continue;

            CreateButtonForPatient(patientGO);
        }
    }

    public void ClearButtons()
    {
         foreach (Transform child in ButtonListParent)
        {
            Destroy(child.gameObject);
        }
    }

    void CreateButtonForPatient(GameObject patientGO)
    {
        GameObject buttonGO =
            Instantiate(ButtonPrefab, ButtonListParent);

        Patient patient =
            patientGO.GetComponent<Patient>();

        buttonGO.name =
            patient.Name + " " + patient.Surname + " Button";

        // ===== UI TEXT =====
        TextMeshProUGUI nameText =
            buttonGO.transform.GetChild(0)
            .GetChild(0)
            .GetComponent<TextMeshProUGUI>();

        TextMeshProUGUI diagnosisText =
            buttonGO.transform.GetChild(0)
            .GetChild(1)
            .GetComponent<TextMeshProUGUI>();

        nameText.text =
            patient.Name + " " + patient.Surname;

        diagnosisText.text =
            patient.Diagnosis;

        // ===== BUTTON SCRIPT SETUP =====
            Patient_Button pb =
        buttonGO.GetComponentInChildren<Patient_Button>();

    pb.Patient = patientGO;
    pb.LoadPatient = LoadPatient;
    pb.patientButtonLoader = GetComponent<PatientButtonLoader>();
    pb.patientEditPage = patientEditPage;

    // ⭐ SAFE ARRAY COPY
    pb.OffStuff = new GameObject[OffStuff.Length];
    pb.OnStuff = new GameObject[OnStuff.Length];
    

    for (int i = 0; i < OffStuff.Length; i++)
    {
        pb.OffStuff[i] = OffStuff[i];
    }

    for (int i = 0; i < OnStuff.Length; i++)
    {
        pb.OnStuff[i] = OnStuff[i];
    }

    }
}
