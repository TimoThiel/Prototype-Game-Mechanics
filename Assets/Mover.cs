using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] public GameObject waypoints;


    [SerializeField] public float currentSpeed = 2f;



    /*public bool hitEnemy = false;*/

    public GameObject bulletPrefab;
    public Transform firepoint;

    private Transform curruntWaypoint;
    void Start()
    {
        var waypoint = waypoints.GetComponent<Waypoint>();
        curruntWaypoint = waypoint.GoToNextWaypoint(curruntWaypoint);
        transform.position = curruntWaypoint.position;


        curruntWaypoint = waypoint.GoToNextWaypoint(curruntWaypoint);

    }

    // Update is called once per frame
    void Update()
    {
        var waypoint = waypoints.GetComponent<Waypoint>();
        transform.position = Vector2.MoveTowards(transform.position, curruntWaypoint.position, currentSpeed * Time.deltaTime);
        if(Vector2.Distance(transform.position, curruntWaypoint.position) < 0.1f)
        {
            curruntWaypoint = waypoint.GoToNextWaypoint(curruntWaypoint);
            
        }
      



    }

}
