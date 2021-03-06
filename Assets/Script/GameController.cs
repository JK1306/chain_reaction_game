using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int width, height;
    public float atomMovementSpeed;
    public GameObject tile, parentGameObject;
    public static GameController instance;
    GameObject spawnTile;
    Vector3 spawnPosition;
    
    private void Start() {
        instance = this;
    }

    void OnEnable() {
        // SpawnTiles();
    }
    void SpawnTiles()
    {
        for(int i=0; i<width; i++){
            for(int j=0; j<height; j++){
                spawnPosition = new Vector3(i * (tile.GetComponent<RectTransform>().rect.width), j * (tile.GetComponent<RectTransform>().rect.height), 0f);
                spawnTile = Instantiate(
                    tile,
                    spawnPosition,
                    Quaternion.identity
                );
                spawnTile.transform.SetParent(parentGameObject.transform);
                Debug.Log("Instantiate Position : "+spawnPosition, spawnTile);
                // spawnTile.transform.position = spawnPosition;
            }
        }
    }
}
