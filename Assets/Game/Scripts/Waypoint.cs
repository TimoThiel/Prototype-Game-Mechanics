using UnityEngine;


public class Waypoint : MonoBehaviour
{
    public GameManage gameManage;
    [SerializeField] private float waypointSize = 1f;
    [SerializeField] private GameObject rotondePrefab;
    [SerializeField] private GameObject kruizingPrefab;
    
    [SerializeField] private GameObject floatingTextPrefab;
    private GameObject floatingText;
    Transform closestTransform;
    Transform currentActive;
    [SerializeField] public GameObject stopPrefab;
   

    public int minStop = 0;
    public int maxStop = 0;
    public int maxRotonde = 1;
    public int minRotonde = 0;
    public int maxKruizing = 0;
    public int minKruizing = 0;
   

    private void Start()
    {
        
   
    }
    private void Update()
    {
       
        if (Input.GetMouseButtonDown(0) && maxRotonde>minRotonde)
        {
            minRotonde += 1;
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
            GameObject rotonde = Instantiate(rotondePrefab,objectPos,Quaternion.identity,transform);

            rotonde.transform.SetSiblingIndex(index);
            for (int i = 0; i < rotonde.transform.childCount; i++)
            {
                GameObject rotondeChild = rotonde.transform.GetChild(i).gameObject;
                rotondeChild.transform.parent = transform;
                rotondeChild.transform.SetSiblingIndex(index);
            }
            Destroy(rotonde.transform.gameObject);
        }
        if (Input.GetMouseButtonDown(0) && maxKruizing>minKruizing)
        {
            minKruizing += 1;
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
            GameObject kruizing = Instantiate(kruizingPrefab, objectPos, Quaternion.identity, transform);

            kruizing.transform.SetSiblingIndex(index);
            for (int i = 0; i < kruizing.transform.childCount; i++)
            {
                GameObject rotondeChild = kruizing.transform.GetChild(i).gameObject;
                rotondeChild.transform.parent = transform;
                rotondeChild.transform.SetSiblingIndex(index);
            }
            Destroy(kruizing.transform.gameObject);
        }

    }
    
    public void BuyStopBoard()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            if (gameManage.money >= 5)
            {
                gameManage.money -= 5;
                maxStop += 1;
               i = Random.Range(1, 8);
                    Instantiate(stopPrefab,transform.GetChild(i));
                
            }
        }

    }

    public void BuyRotonde()
    {
        if(gameManage.money >= 10)
        {
            gameManage.money -= 10;
            maxRotonde += 1;
        }
    }
    public void BuyKruising()
    {
        if(gameManage.money >= 20)
        {
            gameManage.money -= 20;
            Debug.Log("Unit Test Money changed: Succesfull");
            maxKruizing += 1;
        }
    }
    private void OnDrawGizmos()
    {
        foreach (Transform t in transform)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(t.position, waypointSize);

        }

        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount - 1; i++)
        {

            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);

        }

    }


    public Transform GoToNextWaypoint(Transform currentWaypoint)
    {
        currentActive = currentWaypoint;
        if (currentWaypoint == null)
        {
            return transform.GetChild(0);
        }

        if (currentWaypoint.GetSiblingIndex() < transform.childCount - 1)
        {
            return transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
        }

        else
        {
            return currentWaypoint;
        }
    }


}
