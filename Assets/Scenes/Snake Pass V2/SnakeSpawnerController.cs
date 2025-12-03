using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SnakeSpawnerController : MonoBehaviour
{
    [Tooltip("Index of the player, tracked by this component. 0 means the 1st player, 1 - the 2nd one, 2 - the 3rd one, etc.")]
    public int playerIndex = 0;
    public GameObject puppet;

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

    void Start()
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

    public void SpawnSnake(Spawner spawner)
    {
        KinectManager manager = KinectManager.Instance;


        if (snakePrefab && manager && manager.IsInitialized() && manager.IsUserDetected(playerIndex))
        {
            GameObject snake = Instantiate(snakePrefab, spawner.spawnPoint.position, Quaternion.identity);
            activeSnake = snake;

           

            // z-axis
            float length = Random.Range(spawner.lengthRange.x, spawner.lengthRange.y);
            
            snake.transform.localScale = new Vector3(length, 0.1f, 0.1f);

            SnakeMover mover = snake.AddComponent<SnakeMover>();
            mover.target = commonTarget;
            mover.speed = Random.Range(spawner.speedRange.x, spawner.speedRange.y);

            // When snake dies
            mover.onDestroyed += () => activeSnake = null;
        }
    }

     void Update() {
        this.transform.position = new Vector3(puppet.transform.position.x, this.transform.position.y, puppet.transform.position.z);
    }
}
