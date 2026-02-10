using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public AudioSource music;
    public GameObject screen;
    public bool paused;
    // Start is called before the first frame update
    public void Pause(bool active)
    {
        music.enabled = active;
        screen.SetActive(!active);
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
