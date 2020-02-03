using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GetTilesPosition : MonoBehaviour
{
    public Grid Grid;
    public Tile tile;
    public Tile tile2;
    public Tilemap tilemap;

    private Vector3Int position;
    private List<Vector3Int> list = new List<Vector3Int>();

    // Start is called before the first frame update
    void Start()
    {
        constructScene();
        InvokeRepeating("DestroyScene", 2.0f, 3.0f);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void constructScene() {
        for(int x = -5; x < 6 ; x++) {
            for(int y = -5; y < 6 ; y++) {
                position = new Vector3Int(x, y, 0);
                tilemap.SetTile(position, tile);
                tilemap.SetColliderType(position, Tile.ColliderType.None);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            RepairScene(Vector3Int.FloorToInt(other.transform.position));
        }
    }

    void DestroyScene() {
        int x = Random.Range(-5,6);
        int y = Random.Range(-5,6);

        position.x = x;
        position.y = y;

        tilemap.SetTile(position, tile2);
        tilemap.SetColliderType(position, Tile.ColliderType.Grid);
        list.Add(position);
    }

    void RepairScene(Vector3Int userPosition) {
        
        Vector3Int coords = userPosition;

        if(list.Exists(element => element == coords)){
            tilemap.SetTile(coords, tile);
            tilemap.SetColliderType(coords, Tile.ColliderType.None);
            list.Remove(coords);
        }
        
    }
}
