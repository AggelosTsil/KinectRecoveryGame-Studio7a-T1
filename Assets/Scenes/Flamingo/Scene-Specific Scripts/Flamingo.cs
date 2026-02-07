using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
                    Animator anim = child.GetComponent<Animator>();
                    Vector3 origin = child.transform.localPosition;
                    anim.SetTrigger("Left");
                    anim.SetTrigger("Death");

                    //brings in next flamingo
                    Move(direction, origin);

                    //removes punched flamingo
                    Destroy(child.gameObject, 3f);
                }
            }
            else if (direction == "RIGHT")
            {
                if ((child.transform.localPosition.x < 3) && (child.transform.localPosition.x > 0))
                {
                    Debug.Log("punched RIGHT");
                    Vector3 origin = child.transform.localPosition;
                    child.GetComponent<Animator>().SetTrigger("Death");

                    //brings in next flamingo
                    Move(direction, origin);

                    //removes punched flamingo
                    Destroy(child.gameObject, 3f);

                    
                }
            }
        }
    }

    void Move(string direction, Vector3 pos)
    {
        if (direction == "RIGHT")
        {
            foreach (Transform child in this.transform)
            {
                if (child.transform.localPosition.x == 4)
                {
                    Debug.Log("moving  " + child.gameObject + " to position " + pos);
                    //child.localPosition = Vector3.MoveTowards(child.localPosition, pos, Time.deltaTime * 0.1f);
                    child.transform.localPosition = pos;
                }
            }
        }
        else
        {
            foreach (Transform child in this.transform)
            {
                if (child.transform.localPosition.x == -2)
                {
                    Debug.Log("moving  " + child.gameObject + " to position " + pos);
                    //child.localPosition = Vector3.MoveTowards(child.localPosition, pos, Time.deltaTime * 0.1f);
                    child.transform.localPosition = pos;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
