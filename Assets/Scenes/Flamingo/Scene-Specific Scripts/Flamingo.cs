using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamingo : MonoBehaviour
{
    public GameObject[] prefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void SpawnFlamingo(string direction)
    {
        if (direction == "LEFT")
        {
            
        }
        else if (direction == "RIGHT")
        {
            
        }
    }

    public void GetPunched(string direction)
    {
        foreach (Transform child in this.transform)
        {
            if (direction == "LEFT")
            {
                if ((child.transform.localPosition.x > -1) && (child.transform.localPosition.x < 0)) //this is bound to the position of the flamingos in world space
                {
                    Debug.Log("punched LEFT");
                    child.GetComponent<Animator>().SetTrigger("Death");
                }
            }
            else if (direction == "RIGHT")
            {
                if ((child.transform.localPosition.x < 3) && (child.transform.localPosition.x > 0))
                {
                    Debug.Log("punched RIGH");
                    child.GetComponent<Animator>().SetTrigger("Death");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
