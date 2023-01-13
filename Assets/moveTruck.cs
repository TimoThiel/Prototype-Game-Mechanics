using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTruck : MonoBehaviour
{
    [SerializeField] public Transform truck, car;
    [SerializeField] public Grid grid;
    public float currentSpeed = 2f;
    public float countdown = 20f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        truck.position = Vector3.MoveTowards(truck.position, new Vector3(7, 8, -1), currentSpeed * Time.deltaTime);
        car.position = Vector3.MoveTowards(car.position, new Vector3(15, 4, -1), currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Truck" )
        {
            currentSpeed = 0;
           
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Truck")
        {
            currentSpeed = 3;
        }
    }
}
