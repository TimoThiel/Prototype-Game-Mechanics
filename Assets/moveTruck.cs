using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveTruck : MonoBehaviour
{
    [SerializeField] public Transform car, finish, start;
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
       /* truck.position = Vector3.MoveTowards(truck.position, new Vector3(7, 8, -1), currentSpeed * Time.deltaTime);*/
        car.position = Vector3.MoveTowards(car.position,finish.position, currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Grass" )
        {
            currentSpeed = 1;
           
        }
        if (collision.gameObject.tag == "Grass"&& collision.gameObject.tag == "Road")
        {
            currentSpeed = 3;
        }
    }

    
    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
