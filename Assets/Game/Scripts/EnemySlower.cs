
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySlower : MonoBehaviour
{
    [SerializeField] private Mover enemies;
  
    public bool collisionIsWorking = false;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Speedbord60")
        {
            Debug.Log("very nice");
            enemies.currentSpeed = 6;
        }
        if (collision.gameObject.tag == "Speedbord30")
        {
            enemies.currentSpeed = 3;
        }
    }
 


}


