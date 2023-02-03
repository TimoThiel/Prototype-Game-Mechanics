using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public int pointsNeeded;
    public static int points;
    public static bool busReachEnd = false;


    private void Update()
    {
        Debug.Log(points);
        /*if(points == pointsNeeded)
        {

        }*/
        if(points >= pointsNeeded && busReachEnd)
        {
            Win();
        }

    }
    void Win()
    {
        SceneManager.LoadScene("Win");
        Finish.points = 0;
        busReachEnd= false;
    }
}
