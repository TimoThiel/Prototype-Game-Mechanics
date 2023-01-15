using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowThePath : MonoBehaviour
{
    [SerializeField] private Transform road, car;
    [SerializeField] private GameObject recht, bocht,kruising;
    private Vector3 current;
    private int bochtTileMax = 0;
    private int bochtTileMin = 0;
    public bool rechtTile = false;
    public bool kruisingTile = false;

    private void Start()
    {
        current= transform.position;
    }
    public void Update()
    {
        KruisingEnable();
        PlaceBocht();
        RechtEnable();
        /*Movement();*/
       /* PlaceRoad();*/
      
       
       
    }
   public void RechtEnable()
    {
        if (rechtTile)
        {
            Instantiate(recht, transform.position, Quaternion.identity);
        }
    }
    public void BochtEnable()
    {

        bochtTileMax += 1;
    }
    void PlaceBocht()
    {
        if (bochtTileMax> bochtTileMin && Input.GetMouseButton(0))
        {
            bochtTileMin += 1;
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 2.0f;       // we want 2m away from the camera position
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            GameObject kruizing = Instantiate(kruising, objectPos, Quaternion.identity, transform);
        }
    }
    public void KruisingEnable()
    {
        if (kruisingTile)
        {
            Instantiate(kruising, transform.position, Quaternion.identity);
        }
    }
    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Grass")
        {
            car.position = current;
        }
    }

    void PlaceRoad()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(road,transform.position,Quaternion.identity);
        }
    }
    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    

}
