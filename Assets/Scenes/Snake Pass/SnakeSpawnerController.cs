using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SnakeSpawnerController : MonoBehaviour
{
    [System.Serializable]
    public class Spawner
    {
        public Transform spawnPoint;
        public float spawnInterval = 2f;

        [Header("Snake Length (Z scale)")]
        public Vector2 lengthRange = new Vector2(1f, 4f);

        [Header("Snake Speed")]
        public Vector2 speedRange = new Vector2(1f, 4f);
    }

    public Spawner rightSpawner;
    public Spawner leftSpawner;
    

    public Transform commonTarget;
    public GameObject snakePrefab;

    private GameObject activeSnake = null; 

    private void Start()
    {
        StartCoroutine(SpawnerRoutine(rightSpawner));
        StartCoroutine(SpawnerRoutine(leftSpawner));
    }

    private IEnumerator SpawnerRoutine(Spawner spawner)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawner.spawnInterval);
            yield return new WaitUntil(() => activeSnake == null);
            SpawnSnake(spawner);
        }
    }

    private void SpawnSnake(Spawner spawner)
    {
        GameObject snake = Instantiate(snakePrefab, spawner.spawnPoint.position, Quaternion.identity);

        activeSnake = snake; 

        // z-axis
        float length = Random.Range(spawner.lengthRange.x, spawner.lengthRange.y);

        snake.transform.localScale = new Vector3(length, 0.1f, 1f);

        SnakeMover mover = snake.AddComponent<SnakeMover>();
        mover.target = commonTarget;
        mover.speed = Random.Range(spawner.speedRange.x, spawner.speedRange.y);

        // When snake dies
        mover.onDestroyed += () => activeSnake = null;
    }
}
