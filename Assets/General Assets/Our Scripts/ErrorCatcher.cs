using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ErrorCatcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrintError()
    {
        string filename = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        ScreenCapture.CaptureScreenshot("/Assets/Screenshots/" + filename);
    }

    public void Screenshot(InputAction.CallbackContext context)
    {
        PrintError();
    }
}
