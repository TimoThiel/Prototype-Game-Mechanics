using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;


    public GameObject other;

    public float speed = 50f;


    public void Start()
    {

    }
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {

        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed*Time.deltaTime;

        /*if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }*/
      
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();
       
        if(enemy == null)
        {
            return;
        }
            enemy.Hit();
            HitTarget();
    }

    public void HitTarget()
    {
        
        Destroy(gameObject);
        return;
    }

  

}
