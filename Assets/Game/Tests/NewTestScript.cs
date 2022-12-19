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

    

}
