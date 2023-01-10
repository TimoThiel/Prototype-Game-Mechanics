
using System.Collections.Generic;
/*using TMPro;*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySlower : MonoBehaviour
{
    [SerializeField] private Mover enemies;
    [SerializeField] private GameManage gameManage;

    public bool collisionIsWorking = false;

    public void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Speedbord60")
        {
            enemies.currentSpeed = 6;
            if (enemies.currentSpeed == 6)
            {
                Debug.Log("Unit Test Car goes Faster: Succesfull ");
            }
            else
            {
                Debug.Log("Unit Test Car goes Faster: Failed ");
            }
        }
       
        if (collision.gameObject.tag == "Speedbord30")
        {
            enemies.currentSpeed = 3;
        }


        if(collision.gameObject.tag == "Truck")
        {
            enemies.currentSpeed = 0;

            if (enemies.currentSpeed == 0)
            {
                gameManage.ChangeAngryMeter(10);
            }
            // Angry meter goes up!!
        }
      
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Truck")
        {
            enemies.currentSpeed = 4;
        }


    }
   


}


