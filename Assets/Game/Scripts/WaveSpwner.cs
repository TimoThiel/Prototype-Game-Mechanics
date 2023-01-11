using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpwner : MonoBehaviour
{
    public Mover move;
    public GameManage gameManage;
    [SerializeField] public GameObject mover;
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public GameObject bossPrefab;
    [SerializeField] public GameObject waypoint;
    [SerializeField] public GameObject waypoint1;
    [SerializeField] public GameObject webs;
    [SerializeField] public GameObject cheats;
    [SerializeField] public GameManage gameManager;
    public Transform SpawnPoint;
    public float moneyTimer = 0;
    public float timeBetweenWaves = 100f;
    private float countdown = 1f;
    public int waveNumber = 1;
    /*public int HP = 50;*/
    private void Start()
    {
        var enemy1 = enemyPrefab.GetComponent<Mover>();
        var enemy = enemyPrefab.GetComponent<Enemy>();
        var web = webs.GetComponent<EnemySlower>();
        enemy.maxHP = 17.5f;
        
        enemy1.currentSpeed = 4;
    }
    void Update()
    {
        var enemy = enemyPrefab.GetComponent<Enemy>();
        /*var cheat = cheats.GetComponent<Cheats>();
        var waypoints = waypoint.GetComponent<Waypoint>();
        var web = webs.GetComponent<EnemySlower>();*/
        if (moneyTimer < 0)
        {
          
            gameManager.ChangeAmount(1);
            moneyTimer = 1;
        }
        moneyTimer-= Time.deltaTime;
        /*web.money +=  Mathf.CeilToInt(Time.deltaTime);*/

        /*web.Update();*/
        /*cheat.Update();*/
        
        if (countdown <= 0)
        {
            
            if (waveNumber < 30)
            {
                
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
                
             
            }
        }
        countdown -= Time.deltaTime;


    }

    IEnumerator SpawnWave()
    {
        var enemy = enemyPrefab.GetComponent<Mover>();
      //  for (int i = 0; i < waveNumber; i++)
       // {
           
            SpawnEnemy();
            SpawnEnemyBoss();
            yield return new WaitForSeconds(2f);
        //}
        gameManage.ChangeWaveAmount(1);
        gameManage.ChangeAngryMeter(5);

        /*waveNumber++;*/
        enemy.currentSpeed *= 1.05f;
        if(enemy.currentSpeed > 5)
        {
            enemy.currentSpeed = 5;
        }

    }

    public void SpawnEnemy()
    {
        enemyPrefab.GetComponent<Mover>().waypoints = waypoint;
        GameObject enemy = Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
        enemy.transform.SetParent(this.transform);
    }
    public void SpawnEnemyBoss()
    {
        bossPrefab.GetComponent<Mover>().waypoints = waypoint1;
        GameObject enemy = Instantiate(bossPrefab, SpawnPoint.position, bossPrefab.transform.rotation);
        enemy.transform.SetParent(this.transform);
        
    }


   
}
