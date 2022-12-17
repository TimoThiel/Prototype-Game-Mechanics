/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopboard : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && maxStop > minStop)
        {
            minStop += 1;
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 2.0f;       // we want 2m away from the camera position
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            closestTransform = transform.GetChild(0);
            int index = 0;
            for (int i = 1; i < transform.childCount; i++)
            {
                 
                if (Vector3.Distance(closestTransform.position, objectPos) > Vector3.Distance(objectPos, transform.GetChild(i).position) && transform.GetChild(i).CompareTag("Waypoint"))
                {
                    index = i;
                    closestTransform = transform.GetChild(i);
                }
            }
            GameObject stopBoard = Instantiate(stopPrefab, objectPos, Quaternion.identity, transform);

            stopBoard.transform.SetSiblingIndex(index);
            for (int i = 0; i < stopBoard.transform.childCount; i++)
            {
                GameObject rotondeChild = stopBoard.transform.GetChild(i).gameObject;
                rotondeChild.transform.parent = transform;
                rotondeChild.transform.SetSiblingIndex(index);
            }
            Destroy(stopBoard.transform.gameObject);
        }
    }
    public void BuyStopBoard()
    {
        if (gameManage.money >= 6)
        {
            gameManage.money -= 6;
            maxStop += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("very stom");
            enemies.currentSpeed = 0.2f;
        }
    }
}
*/