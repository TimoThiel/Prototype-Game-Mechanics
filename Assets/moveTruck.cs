using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTruck : MonoBehaviour
{
    [SerializeField] public Transform car, finish, start;
    [SerializeField] public Grid grid;
    public float currentSpeed = 2f;
    public float countdown = 20f;
    public int checkpointCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(DragDrop.RoadToCheckpoint.Count<= 0)
        {
            return;
        }
        SetRotation(DragDrop.RoadToCheckpoint[0]);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(checkpointCount >= DragDrop.RoadToCheckpoint.Count)
        {
            ResetTheGame();
            return;
            
        }
        car.position = Vector3.MoveTowards(car.position, DragDrop.RoadToCheckpoint[checkpointCount], currentSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, DragDrop.RoadToCheckpoint[checkpointCount])< 0.2f)
        {
            checkpointCount++;
            if(checkpointCount < DragDrop.RoadToCheckpoint.Count)
            {
                SetRotation(DragDrop.RoadToCheckpoint[checkpointCount]);
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
        DragDrop.RoadToCheckpoint = new List<Vector3>();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
