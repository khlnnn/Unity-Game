using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager1 : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn =0;
    public float tileLength = 100;

    void Start()
    {
        SpawnTile(0);
        SpawnTile(1);
        SpawnTile(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnTile(int tileIndex)
    {
        Instantiate(tilePrefabs[tileIndex],transform.forward * zSpawn, transform.rotation);
        zSpawn += tileLength;
    }
}
