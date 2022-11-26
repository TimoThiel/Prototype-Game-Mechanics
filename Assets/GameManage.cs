using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    private List<GameObject> tiles = new List<GameObject>();

    [SerializeField] private GameObject obj;

    Transform closestTransform;
    public TextMeshProUGUI geld;
    public TextMeshProUGUI rotondeAmount;
    public int money;
    public int rotondes;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void ChangeAmount(int text)
    {
        this.money += text;
    }
    public void ChangeRotondeAmount(int text)
    {
        this.rotondes += text;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && money >= 20f)
        {

           
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
            GameObject rotonde = Instantiate(obj, objectPos, Quaternion.identity, transform);

            rotonde.transform.SetSiblingIndex(index);
            for (int i = 0; i < rotonde.transform.childCount; i++)
            {
                GameObject rotondeChild = rotonde.transform.GetChild(i).gameObject;
                rotondeChild.transform.parent = transform;
                rotondeChild.transform.SetSiblingIndex(index);
            }
            Destroy(rotonde.transform.gameObject);
        }
        money -= 20;
        

        geld.text = "Money: " + money.ToString();
        rotondeAmount.text = "rotondes: " + rotondes.ToString();
    }
}
