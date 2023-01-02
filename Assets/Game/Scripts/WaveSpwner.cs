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
    [SerializeField] public GameObject waypoint;
    [SerializeField] public GameObject webs;
    [SerializeField] public GameObject cheats;
    [SerializeField] public GameManage gameManager;
    public Transform SpawnPoint;
    public float moneyTimer = 0;
    public float timeBetweenWaves = 100f;
    private float countdown = 5f;
    public int waveNumber = 1;
    /*public int HP = 50;*/
    private void Start()
    {
        var enemy1 = enemyPrefab.GetComponent<Mover>();
        var enemy = enemyPrefab.GetComponent<Enemy>();
        var web = webs.GetComponent<EnemySlower>();
        enemy.maxHP = 17.5f;
        
        enemy1.currentSpeed = 3;
    }
    void Update()
    {
        
        /*var cheat = cheats.GetComponent<Cheats>();
        var waypoints = waypoint.GetComponent<Waypoint>();
        var web = webs.GetComponent<EnemySlower>();*/
        if(moneyTimer < 0)
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
                
                if (waveNumber >= 19)
                {
                    move.currentSpeed = 5;
                    /*waypoints.maxRotonde += 1;*/
                    

                }
                else if(waveNumber >= 20)
                {
                    move.currentSpeed = 3;
                }
            }
        }
        countdown -= Time.deltaTime;


    }

    IEnumerator SpawnWave()
    {
        var enemy = enemyPrefab.GetComponent<Enemy>();
        for (int i = 0; i < waveNumber; i++)
        {
           
            SpawnEnemy();
            
            yield return new WaitForSeconds(0.5f);
        }
        gameManage.ChangeWaveAmount(1);
        waveNumber++;
        enemy.maxHP *= 1.1f;
    }

    public void SpawnEnemy()
    {
        enemyPrefab.GetComponent<Mover>().waypoints = waypoint;
        GameObject enemy = Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
        enemy.transform.SetParent(this.transform);
    }
   
}
