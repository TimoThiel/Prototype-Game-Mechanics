using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTruck : MonoBehaviour
{
    [SerializeField] public GameManages gameManages;
    [SerializeField] public Transform car, finish, start;
    [SerializeField] public Grid grid;
    public float currentSpeed = 2f;
    public float countdown = 20f;
    public int checkpointCount = 0;
    private int canWin = 0;
    // Start is called before the first frame update
    void Start()
    {
        

        if (DragDrop.RoadToCheckpoint.Count<= 0)
        {
            return;
        }
        SetRotation(DragDrop.RoadToCheckpoint[0].transform.position);
    }
  
    // Update is called once per frame
    void Update()
    {
        /*Debug.Log(canWin);*/
        if ((checkpointCount >= DragDrop.RoadToCheckpoint.Count && Finish.points == 2 && Finish.money >= 0) ||
            (checkpointCount >= DragDrop.RoadToCheckpoint.Count && Finish.pointsLevel2 == 2 && Finish.money >= 0) ||
            (checkpointCount >= DragDrop.RoadToCheckpoint.Count && Finish.pointsLevel3 == 2 && Finish.money >= 0))
        {
            Finish.busReachEnd = true;
            ResetTheGame();
            return;
        }

        else if (checkpointCount >= DragDrop.RoadToCheckpoint.Count && Finish.points < 2 && Finish.money >= 0 || checkpointCount >= DragDrop.RoadToCheckpoint.Count && Finish.pointsLevel2 < 2 && Finish.money >= 0 || checkpointCount >= DragDrop.RoadToCheckpoint.Count && Finish.pointsLevel3 < 2 && Finish.money >= 0)
        {
            Finish.busReachEnd = false;
            ResetTheGame();
            return; 
        }
        /*if(checkpointCount > 1)
        {
            Debug.Log(DragDrop.RoadToCheckpoint.Count);
            Debug.Log(CheckConnectionPoints(DragDrop.RoadToCheckpoint[checkpointCount - 1], DragDrop.RoadToCheckpoint[checkpointCount]));
            if (!CheckConnectionPoints(DragDrop.RoadToCheckpoint[checkpointCount - 1], DragDrop.RoadToCheckpoint[checkpointCount]))
            {
                
                return;
            }
        }*/
       
        car.position = Vector3.MoveTowards(car.position, DragDrop.RoadToCheckpoint[checkpointCount].transform.position, currentSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, DragDrop.RoadToCheckpoint[checkpointCount].transform.position) < 0.2f)
        {
            
            checkpointCount++;
            if (checkpointCount < DragDrop.RoadToCheckpoint.Count)
            {
                SetRotation(DragDrop.RoadToCheckpoint[checkpointCount].transform.position);
            }
        }
        
    }
    void SetRotation(Vector3 target)
    {
        var x = transform.position.x- target.x;
        var y = transform.position.y- target.y;
        if(Mathf.Abs(x)>= Mathf.Abs(y))
        {
            car.rotation = Quaternion.Euler(0,0,x>=0? -180: 0);
        }
        else
        {
            car.rotation = Quaternion.Euler(0, 0, y >= 0 ? -90 : 90);
        }
    }
   
    public void ResetTheGame()
    {
        
        DragDrop.RoadToCheckpoint = new List<DragDrop>();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        /*Finish.points = 0;*/
        
    }
    bool CheckConnectionPoints(DragDrop current, DragDrop next)
    {
        Vector2 distance = current.transform.position - next.transform.position;
        if (MathF.Abs(distance.y) <=.2f)
        {
            if (distance.x <= 0)
            {
                if (current.leftConnect && next.rightConnect)
                {
                    return true;
                }
            }
            else
            {
                if (current.rightConnect && next.leftConnect)
                {
                    return true;
                }
            }
        }
       if(MathF.Abs(distance.x) <= .2f)
        {
            if(distance.y <= 0)
            {
                if (current.topConnect && next.bottomConnect)
                {
                    return true;
                }
            }
            else
            {
                if (current.bottomConnect && next.topConnect)
                {
                    return true;
                }
            }
        }
      
        ResetTheGame();
        return false;
    }
}
