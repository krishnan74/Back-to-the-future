using UnityEngine;
using UnityEngine.Tilemaps;
using FlowControllerlast;
public class PlutoSpawner : MonoBehaviour
{
    public GameObject PlutoPrefab;
    public float spawnInterval;
    public float spawnRadius = 10f;
    public Tilemap targetTilemap;
    private Transform target;

    private BoundsInt tileBounds;

    private void Start()
    {
        if(StateManager.increasedPlutoSpawn == 0){
            spawnInterval = 5f;
        }

        if(StateManager.increasedPlutoSpawn == 1){
            spawnInterval = 4f;
        }

        if(StateManager.increasedPlutoSpawn == 2){
            spawnInterval = 3f;
        }

        if(StateManager.increasedPlutoSpawn == 3){
            spawnInterval = 1f;
        }

        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (targetTilemap != null)
            tileBounds = targetTilemap.cellBounds;

        InvokeRepeating("SpawnPluto", 0f, spawnInterval);
    }

    private void SpawnPluto()
    {
        if (targetTilemap == null)
        {
            Debug.LogWarning("Target Tilemap not assigned!");
            return;
        }

        Vector2 randomPosition = GetRandomTilePosition();

        if (randomPosition != Vector2.zero)
            Instantiate(PlutoPrefab, randomPosition, Quaternion.identity);
    }

    private Vector2 GetRandomTilePosition()
    {
        Vector2Int randomPosition;
        Vector3Int cellPosition;
        TileBase tile;

        int maxAttempts = 100;
        int attemptCount = 0;

        do
        {
            randomPosition = new Vector2Int(
                Random.Range(tileBounds.xMin, tileBounds.xMax),
                Random.Range(tileBounds.yMin, tileBounds.yMax)
            );

            cellPosition = new Vector3Int(randomPosition.x, randomPosition.y, 0);
            tile = targetTilemap.GetTile(cellPosition);

            attemptCount++;
        }
        while (tile == null && attemptCount < maxAttempts);

        if (tile != null)
            return targetTilemap.GetCellCenterWorld(cellPosition);

        return Vector2.zero;
    }
}
