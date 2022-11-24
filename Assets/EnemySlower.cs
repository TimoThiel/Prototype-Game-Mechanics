
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySlower : MonoBehaviour
{
    [SerializeField] private Mover enemies;
  
    public bool collisionIsWorking = false;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Web")
        {
            enemies.currentSpeed = 1;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Web")
        {
            enemies.currentSpeed = 3;
        }
    }
   


}


