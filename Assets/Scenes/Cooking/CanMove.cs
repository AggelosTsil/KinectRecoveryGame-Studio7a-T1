using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CanMove : MonoBehaviour
{
    public Vector3 Dir;
    public int RNG;
    // Start is called before the first frame update
    void Start()
    {
        RNG = Random.Range(0, 2);
        switch (RNG)
        {
            case 0: Dir = (Vector3.left);
            break; 
            case 1: Dir = (Vector3.right);
            break;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {

        this.transform.Translate(Dir * Time.deltaTime);

    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Right": Dir = Vector3.left;
            break;

            case "Left": Dir = Vector3.right;
            break;

        }
        //UnityEngine.Debug.Log("OnCollisionEnter");
    }
}
