using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float hitPoints;

    public float maxHP = 1000f;
    
    void Awake()
    {
        
        hitPoints = maxHP;
    }

    public void Hit()
    {
        hitPoints -= 10;
    }
    public void Update()
    {
        hitPoints -= Time.deltaTime;
        if(hitPoints <= 0)
        {
            Die();
            
        }
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }

}
