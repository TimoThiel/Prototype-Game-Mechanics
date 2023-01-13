using System.Collections;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    [SerializeField] private test _tilePrefab, _roadTile;
    [SerializeField] private Transform camera;

    [SerializeField] public Transform startPoint, carStart;
    [SerializeField] private GameObject truck, car;

    private float countdown = 1f;
    public float timeBetweenWaves = 100f;
    public float currentSpeed = 2f;
    private void Start()
    {
        GenerateGrid();

    }
    private void Update()
    {
        
        if (countdown <= 0)
        {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
            
        }
        countdown -= Time.deltaTime;
        
    }
    void GenerateGrid()
    {
        for(int x =0; x < _width; x++)
        {
            for(int y =0; y < _height; y++)
            {
                /*var roadPlaced = Random.Range(0,6) == 3? _roadTile: _tilePrefab;*/
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x,y),Quaternion.identity);
                spawnedTile.name = $"tile{x} {y}";
                var spawnedRoadTile = Instantiate(_roadTile, new Vector3(7,y), Quaternion.identity);
                var spawnedRoadTileHr = Instantiate(_roadTile,new Vector3(x,4), Quaternion.identity);
                startPoint.position = new Vector3(7, 0,-1);
                carStart.position = new Vector3(0, 4, -1);
                spawnedTile.Init(x,y);
                spawnedRoadTile.Init(x,y);
                spawnedRoadTileHr.Init(x,y);
                
                spawnedTile.transform.SetParent(this.transform);
                spawnedRoadTile.transform.SetParent(this.transform);
                spawnedRoadTileHr.transform.SetParent(this.transform);
                

            }
        }

        camera.transform.position = new Vector3((float)_width/2- 0.5f,(float)_height/2- 0.5f, -10);
    }

    void SpawnCar()
    {
        Instantiate(truck, startPoint.position, Quaternion.Euler(0f,0f,90));
        Instantiate(car, carStart.position, Quaternion.Euler(0f,0f,0f));
    }
    IEnumerator SpawnWave()
    {

       SpawnCar();
        
        yield return new WaitForSeconds(2f);
    }
}

