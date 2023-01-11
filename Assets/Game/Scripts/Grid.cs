using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    [SerializeField] private test _tilePrefab, _roadTile;
    [SerializeField] private Transform camera;

    private void Start()
    {
        GenerateGrid();
    }
    void GenerateGrid()
    {
        for(int x =0; x < _width; x++)
        {
            for(int y =0; y < _height; y++)
            {
                var roadPlaced = Random.Range(0,6) == 3? _roadTile: _tilePrefab;
                var spawnedTile = Instantiate(roadPlaced, new Vector3(x,y),Quaternion.identity);
                spawnedTile.name = $"tile{x} {y}";

                
                spawnedTile.Init(x,y);
            }
        }

        camera.transform.position = new Vector3((float)_width/2- 0.5f,(float)_height/2- 0.5f, -10);
    }
}

