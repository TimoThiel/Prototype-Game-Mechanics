
using System.Collections.Generic;

using UnityEngine;

public class EnemySlower : MonoBehaviour
{
    private List<GameObject> tiles = new List<GameObject>();


    public float money;
    [SerializeField] private Mover enemies;
    [SerializeField] private GameObject obj;
    [SerializeField] private GameObject floatingTextPrefab;
    private GameObject floatingText;
    public bool collisionIsWorking = false;
  
    void Start()
    {
        floatingText = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    public void Update()
    {
       
      
        if (Input.GetMouseButtonDown(1) && money >= 20f)
        {
            
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 2.0f;       // we want 2m away from the camera position
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            tiles.Add(Instantiate(obj, objectPos, Quaternion.identity));
            money -= 20;
        }


    }
    void ShowAmount(string text)
    {
        if (floatingTextPrefab)
        {
            floatingText.GetComponent<TextMesh>().text = text;
            floatingText.transform.position = new Vector2(-10f, 3.5f);
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


