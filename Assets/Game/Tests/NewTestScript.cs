using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NUnit.Framework.Internal;
using UnityEngine.SceneManagement;

public class NewTestScript 
{
    private tower towers;
    private WaveSpwner spawnEnemy;
    private Mover move;
    private GameManage manage;
    private Waypoint waypoint;

    // 1
    [UnityTest]
    public IEnumerator DoCarMoveFaster()
    {
        // 2
        SceneManager.LoadScene("SampleScene");

        yield return new WaitForSeconds(9.1f);

        move = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Mover>();
        // 3
        Assert.AreEqual(6,move.currentSpeed);
        // 4
        Object.Destroy(move.gameObject);
    }
    [UnityTest]
    public IEnumerator DoesTheyCarExplodeWhileCollidingWithTheTower()
    {
        //1
        SceneManager.LoadScene("SampleScene");
        //2
        yield return new WaitForSeconds(22);
        //3
        move = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Mover>();
        towers = GameObject.FindGameObjectWithTag("Tower").GetComponent<tower>();
        //4
        Assert.IsTrue(towers.explosion);
        
    }



}
