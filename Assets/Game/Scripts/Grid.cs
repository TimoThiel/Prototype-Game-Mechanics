using System.Collections;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private GameManages gameManages;
    [SerializeField] private int _width, _height;

    [SerializeField] private test _tilePrefab, _roadTile, _obstacleTile, _waterTile;
    [SerializeField] private Transform camera;

    [SerializeField] public Transform startPoint, carStart;
    [SerializeField] private GameObject truck, car;

    public float tijdCount;
    private float countdown = 1f;
    public float timeBetweenWaves = 100f;
    public float currentSpeed = 2f;

    
    private void Start()
    {
        GenerateGrid();

    }
    private void Update()
    {
        
        if (tijdCount < 0)
        {

            gameManages.ChangeTijd(1);
            tijdCount = 1;
        }
        tijdCount -= Time.deltaTime;
        if (countdown <= 0)
        {
               /* StartCoroutine(SpawnWave());*/
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
                var spawnedRoadTile = Instantiate(_roadTile, new Vector3(0, 0), Quaternion.identity);
                var spawnedRoadTileHr = Instantiate(_roadTile, new Vector3(7, 5), Quaternion.identity);
                spawnedTile.name = $"tile{x} {y}";
                
             
               var waterTile = Instantiate(_waterTile,new Vector3(3, 2), Quaternion.identity);
                var obstacleTile = Instantiate(_obstacleTile, new Vector3(4, 5), Quaternion.identity);
                var obstacleTileHr = Instantiate(_obstacleTile, new Vector3(2, 1), Quaternion.identity);
                startPoint.position = new Vector3(7, 0,-1);
                
        
                spawnedTile.Init(x,y);
/*                spawnedRoadTile.Init(x,y);
                spawnedRoadTileHr.Init(x,y);*/

                
                spawnedTile.transform.SetParent(this.transform);
                spawnedRoadTile.transform.SetParent(this.transform);
                spawnedRoadTileHr.transform.SetParent(this.transform);
                obstacleTile.transform.SetParent(this.transform);


            }
        }

        camera.transform.position = new Vector3((float)_width/2- 0.5f,(float)_height/2- 0.5f, -8);
    }

 /*   void SpawnCar()
    {
        Instantiate(truck, startPoint.position, Quaternion.Euler(0f,0f,90));
        Instantiate(car, carStart.position, Quaternion.Euler(0f,0f,0f));
    }
    IEnumerator SpawnWave()
    {

       SpawnCar();
        
        yield return new WaitForSeconds(2f);
    }*/

  
}

