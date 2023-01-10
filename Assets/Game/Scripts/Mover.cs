using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Mover : MonoBehaviour
{
    [SerializeField] public GameObject waypoints;


    [SerializeField] public float currentSpeed = 2f;



    /*public bool hitEnemy = false;*/
    private Transform target;
    public GameObject bulletPrefab;
    public Transform firepoint;
    public string enemyTag = "Waypoint";
    public float range = 1f;
    private Transform curruntWaypoint;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        var waypoint = waypoints.GetComponent<Waypoint>();
        curruntWaypoint = waypoint.GoToNextWaypoint(curruntWaypoint);
        transform.position = curruntWaypoint.position;


        curruntWaypoint = waypoint.GoToNextWaypoint(curruntWaypoint);

    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnem = null;

        foreach (GameObject enemy in enemies)
        {
            float distaneToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distaneToEnemy < shortestDistance)
            {
                shortestDistance = distaneToEnemy;
                nearestEnem = enemy;
            }
        }
        if (nearestEnem != null && shortestDistance <= range)
        {
            target = nearestEnem.transform;
        }
        else
        {
            target = null;
        }
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

        if (target == null)
        {
            return;
        }

        Vector3 diff = target.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 180);

        
    }

}
