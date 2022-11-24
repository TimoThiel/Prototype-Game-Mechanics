
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySlower : MonoBehaviour
{
    private List<GameObject> tiles = new List<GameObject>();


    [SerializeField] private GameManager gameManager;
    [SerializeField] private Mover enemies;
    [SerializeField] private GameObject obj;
  
    public bool collisionIsWorking = false;
   


    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
        if (Input.GetMouseButtonDown(1) && gameManager.money >= 20f)
        {
            
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 2.0f;       // we want 2m away from the camera position
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            tiles.Add(Instantiate(obj, objectPos, Quaternion.identity));
            gameManager.money -= 20;
        }


    }
   
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


