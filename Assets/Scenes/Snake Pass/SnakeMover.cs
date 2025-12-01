using UnityEngine;
using System;

public class SnakeMover : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;

    public Action onDestroyed;   // <-- NEW callback

    private void Update()
    {
        if (target == null)
        {
            onDestroyed?.Invoke();
            Destroy(gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            onDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}
