using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float X_pos;
    public float spawnInterval = 2f;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }

    private void SpawnObstacle()
    {
        // Generate a random position within the specified y range
        float randomY = Random.Range(minY, maxY);
        Vector2 randomPosition = new Vector2(X_pos, randomY);

        // Instantiate the obstacle prefab at the random position
        Instantiate(obstaclePrefab, randomPosition, Quaternion.identity);
    }

    
    // Update is called once per frame

}
