using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public int pointsNeeded;
    public static int time;
    public static int money;
    public static int points;
    public static int pointsLevel2;
    public static int pointsLevel3;
    public static bool busReachEnd = false;


    private void Update()
    {
        Debug.Log(points);
        Debug.Log(busReachEnd);
        /*if(points == pointsNeeded)
        {

        */
        if (points >= pointsNeeded  && busReachEnd )
        {
            Win();
        }
        if (pointsLevel2 >= pointsNeeded  && busReachEnd )
        {
            WinLevel2();
        }
        if(pointsLevel3 >= pointsNeeded && busReachEnd)
        {
            WinLevel3();
        }

    }
    void Win()
    {
        SceneManager.LoadScene("Level3");
        Finish.points = 0;
        busReachEnd= false;
    }
    void WinLevel2()
    {
        SceneManager.LoadScene("Win");
        Finish.pointsLevel2 = 0;
        busReachEnd = false;
    }
    void WinLevel3()
    {
        SceneManager.LoadScene("Level2");
        Finish.pointsLevel3 = 0;
        busReachEnd = false;
    }
}
