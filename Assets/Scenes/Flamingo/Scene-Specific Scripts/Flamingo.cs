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
        Vector3 SpawnPointLeft = new(-2,-0.8f,0);
        Vector3 SpawnPointRight = new(4,-0.8f,0);
        GameObject selected = prefabs[0]; //doesnt like it unless i initialise it apparently
        int rng = Random.Range(1,5);
        Debug.Log("rng is " + rng);
        switch (rng)
        {
            case 1: selected = prefabs[0];
            break;
            case 2: selected = prefabs[0];
            break;
            case 3: selected = prefabs[1];
            break;
            case 4: selected = prefabs[2];
            break;
            default: Debug.Log("<color=red> op malakia </color>");
            break;
            
        }
        GameObject fresh = null;
        if (direction == "LEFT")
        {
            fresh = Instantiate(selected,this.transform);
            fresh.transform.localPosition = SpawnPointLeft;
        }
        else if (direction == "RIGHT")
        {
            fresh = Instantiate(selected,this.transform);
            fresh.transform.localPosition = SpawnPointRight;
        }
        GetComponentInParent<Wallchange>().flamingoSprites.Add(fresh.GetComponentInChildren<SpriteRenderer>()); //wall change now counts this flamingo as a child too
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
                    child.GetComponentInChildren<AudioSource>().enabled = true;
                    child.gameObject.tag = "dead";
                     Debug.Log("removing " + child.GetComponentInChildren<SpriteRenderer>() + " SpriteRenderer");
                    GetComponentInParent<Wallchange>().flamingoSprites.Remove(child.GetComponentInChildren<SpriteRenderer>());

                    //brings in next flamingo
                    Move(direction, origin);
                    SpawnFlamingo(direction);

                    //removes punched flamingo
                    Destroy(child.gameObject, 3f);
                    break;
                }
            }
            else if (direction == "RIGHT")
            {
                if ((child.transform.localPosition.x < 3) && (child.transform.localPosition.x > 0))
                {
                    Debug.Log("punched RIGHT");
                    Vector3 origin = child.transform.localPosition;
                    child.GetComponent<Animator>().SetTrigger("Death");
                    child.gameObject.tag = "dead";
                    Debug.Log("removing " + child.GetComponentInChildren<SpriteRenderer>() + " SpriteRenderer");
                    GetComponentInParent<Wallchange>().flamingoSprites.Remove(child.GetComponentInChildren<SpriteRenderer>());
                    //brings in next flamingo
                    Move(direction, origin);
                    SpawnFlamingo(direction);

                    //removes punched flamingo
                    Destroy(child.gameObject, 3f);
                    break;

                    
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
                    //child.localPosition = Vector3.MoveTowards(child.localPosition, pos, Time.deltaTime * 1f);
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
