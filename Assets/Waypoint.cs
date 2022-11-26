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
    public int maxRotonde = 1;
    public int minRotonde = 0;

    private void Start()
    {
 
   
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && gameManage.money >= 30f)
        {
            gameManage.rotondes += 1;
            gameManage.money -= 30;
            gameManage.ChangeRotondeAmount(1);
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
        if (Input.GetMouseButtonDown(1) && gameManage.money >= 20f)
        {
            gameManage.money -= 20;
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
            GameObject rotonde = Instantiate(kruizingPrefab, objectPos, Quaternion.identity, transform);

            rotonde.transform.SetSiblingIndex(index);
            for (int i = 0; i < rotonde.transform.childCount; i++)
            {
                GameObject rotondeChild = rotonde.transform.GetChild(i).gameObject;
                rotondeChild.transform.parent = transform;
                rotondeChild.transform.SetSiblingIndex(index);
            }
            Destroy(rotonde.transform.gameObject);
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
