using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NUnit.Framework.Internal;
using UnityEngine.SceneManagement;

public class NewTestScript 
{
    private tower towers;
    private EnemySlower slower;
    private Mover move;
    private GameManage manage;
    private Waypoint waypoint;

    // 1
    [UnityTest]
    public IEnumerator DoCarMoveFaster()
    {
        // 2
        SceneManager.LoadScene("SampleScene");

        yield return new WaitForSeconds(6f);

        move = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Mover>();
        slower = GameObject.FindGameObjectWithTag("Speedbord60").GetComponent<EnemySlower>();
        // 3
        move.transform.position = slower.transform.position;
        yield return new WaitForSeconds(0.2f);
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
        yield return new WaitForSeconds(6);
        //3
        move = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Mover>();
        towers = GameObject.FindGameObjectWithTag("Tower").GetComponent<tower>();

        move.transform.position = towers.transform.position;
        yield return new WaitForSeconds(0.2f);
        //4
        Assert.IsTrue(towers.explosion);
        
    }
    [UnityTest]
    public IEnumerator Does()
    {
        //1
        SceneManager.LoadScene("SampleScene");
        //2
        yield return new WaitForSeconds(0);
        //3
        

    }



}
