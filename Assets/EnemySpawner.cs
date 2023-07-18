using UnityEngine;
using FlowControllerlast;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2.5f;
    public float spawnRadius = 10f;
    private Transform target;


    private void Start()
    {
        // Start spawning enemies repeatedly based on the spawn interval
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void SpawnEnemy()
    {
        // Generate a random position within the spawn radius
        Vector2 randomPosition = (Vector2)target.position + Random.insideUnitCircle * spawnRadius;

        // Instantiate the enemy prefab at the random position
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    }
}
