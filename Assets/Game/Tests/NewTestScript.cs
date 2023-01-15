/*using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NUnit.Framework.Internal;
using UnityEngine.SceneManagement;

public class NewTestScript 
{
    private tower towers;
    private GameObject slower;
    private Mover move;
    private GameManage manage;
    private Waypoint waypoint;

    // 1
    [UnityTest]
    public IEnumerator DoCarMoveFaster()
    {
        // 2
        SceneManager.LoadScene("SampleScene");

        yield return new WaitForSeconds(2f);

        move = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Mover>();
        slower = GameObject.FindGameObjectWithTag("Speedbord60");
        // 3
        move.currentSpeed = 0;
        yield return new WaitForSeconds(0.2f);
        Debug.Log(slower == null);
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
        yield return new WaitForSeconds(2);
        //3
        move = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Mover>();
        towers = GameObject.FindGameObjectWithTag("Tower").GetComponent<tower>();

        move.transform.position = towers.transform.position;
        yield return new WaitForSeconds(0.2f);
        //4
        Assert.IsTrue(towers.explosion);
        
    }
    [UnityTest]
    public IEnumerator DoesStopbordSpawnOnChild1()
    {
        //1
        SceneManager.LoadScene("SampleScene");
        //2
        yield return new WaitForSeconds(1);
        //3
        waypoint = GameObject.FindGameObjectWithTag("WaypointParent").GetComponent<Waypoint>();
        waypoint.gameManage.money = 6;
        yield return new WaitForSeconds(0.1f);
        waypoint.BuyStopBoard();
        yield return new WaitForSeconds(1);
        waypoint.stopPrefab = GameObject.FindGameObjectWithTag("Stop");
        Assert.AreEqual(waypoint.transform.GetChild(1).position, waypoint.stopPrefab.transform.position);
        
    }
    [UnityTest]
    public IEnumerator DoesYourMoneyWork()
    {
        SceneManager.LoadScene("SampleScene");

        yield return new WaitForSeconds(0.1f);
        waypoint = GameObject.FindGameObjectWithTag("WaypointParent").GetComponent<Waypoint>();
        waypoint.gameManage.money = 15;
        waypoint.BuyKruising();
        Assert.AreEqual(0,waypoint.gameManage.money);
    }



}
*/