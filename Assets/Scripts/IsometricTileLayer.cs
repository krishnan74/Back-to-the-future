using UnityEngine;
using UnityEngine.Tilemaps;

public class IsometricTileLayer : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject tilePrefab;
    public string targetLayer = "WallTile"; // Name of the layer to set for the tiles


    void Start()
    {
        // Create a parent GameObject for the tile layer
        GameObject tileLayer = new GameObject("Tile Layer");

        tileLayer.transform.parent = transform;

        // Loop through all the cells in the Tilemap
        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(position.x, position.y, position.z);

            // Check if the current cell has a tile
            if (tilemap.HasTile(localPlace))
            {
                // Get the tile at the current position
                TileBase tile = tilemap.GetTile(localPlace);

                // Create a new GameObject for the tile
                GameObject tileGO = Instantiate(tilePrefab, tilemap.CellToWorld(localPlace), Quaternion.identity);

                // Attach the tile sprite or other components to the GameObject
                // ...

                // Set the parent of the tile GameObject to the tile layer GameObject
                tileGO.transform.parent = tileLayer.transform; 
                tileGO.layer = LayerMask.NameToLayer(targetLayer);
            }
        }
    }
}
