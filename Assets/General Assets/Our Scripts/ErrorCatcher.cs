using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class ErrorCatcher : MonoBehaviour
{
    private string directory;
    // Start is called before the first frame update
    void Start()
    {
        directory = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Screenshots"); //sets screenshot path to screenshots folder
        
        if (!Directory.Exists(directory)) //If no screenshots folder exists
        {
            Directory.CreateDirectory(directory); //creates one
            Debug.Log(directory + " directory created");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrintError()
    {
        string filename = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        ScreenCapture.CaptureScreenshot(Path.Combine(directory, filename));
        Debug.Log("Took screenshot " + Path.Combine(directory, filename));
    }

    public void Screenshot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PrintError();
        }
        
    }
}
