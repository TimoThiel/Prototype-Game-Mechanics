using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    [SerializeField] private Canvas canvas;
    public static List<Vector3> RoadToCheckpoint = new List<Vector3>();
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    
    private bool topConnect, leftConnect, rightConnect, bottomConnect;
    [SerializeField] private bool isCorner;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup= GetComponent<CanvasGroup>();
        if (isCorner)
        {
            leftConnect = false;
            rightConnect = true;
            bottomConnect = true;
            topConnect = false;
        }
        else
        {
            leftConnect = true; 
            rightConnect = true; 
            bottomConnect =false; 
            topConnect = false;
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
         
            ResetTheGame();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StartGame();
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        rectTransform.anchoredPosition += eventData.delta/ canvas.scaleFactor;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rectTransform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 90);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rectTransform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 90);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        
    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void StartGame()
    {
        SpawnCar();
        MoveCar();
    }
    void SpawnCar()
    {
      /*  Instantiate(car, new Vector3(0,0,0), Quaternion.Euler(0f, 0f, 0f));*/
    }
    void MoveCar()
    {
        
    }
    void RotateConnectionPoints()
    {
        if (isCorner)
        {
            switch (transform.rotation.z)
            {
                case 0:
                    leftConnect = false;
                    rightConnect = true;
                    bottomConnect = true;
                    topConnect = false;
                    break;
                case 90:
                    leftConnect = false;
                    rightConnect = true;
                    bottomConnect = false;
                    topConnect = true;
                    break;
                case -180:
                    leftConnect = true;
                    rightConnect = false;
                    bottomConnect = false;
                    topConnect = true;
                    break;
                case -90:
                    leftConnect = true;
                    rightConnect = false;
                    bottomConnect = true;
                    topConnect = false;
                    break;
            }
        }
        else
        {
            leftConnect = !leftConnect;
            rightConnect = !rightConnect;
            bottomConnect = !bottomConnect;
            topConnect = !topConnect;
        }
    }
}
