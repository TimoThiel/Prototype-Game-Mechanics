using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcherTurret : MonoBehaviour
{
    private Transform target;
    public float range = 1f;
    public Transform partToRotate;

    public string enemyTag = "Enemy";


    public float fireRate = 3f;
    private float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firepoint;
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnem = null;

        foreach(GameObject enemy in enemies)
        {
            float distaneToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if(distaneToEnemy < shortestDistance)
            {
                shortestDistance = distaneToEnemy;
                nearestEnem = enemy;
            }
        }
        if(nearestEnem != null && shortestDistance <= range)
        {
            target = nearestEnem.transform;
        }
        else
        {
            target = null;
        }
    }
     void Update()
    {
        if(target == null)
        {
            return;
        }
        // partToRotate.LookAt(target.position, new Vector3(0f,0f,Vector3.forward.z));

        Vector3 diff = target.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);


        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO =(GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
