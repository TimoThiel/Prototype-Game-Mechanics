using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    [SerializeField] private Canvas canvas;
    public static List<DragDrop> RoadToCheckpoint = new List<DragDrop>();
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public static DragDrop CurrentDragDrop { get; private set; }
    
    public bool isDragging = false;
    public bool topConnect, leftConnect, rightConnect, bottomConnect;
    [SerializeField] private bool isCorner;
    int rotation;

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
        if (Input.GetKeyDown(KeyCode.Space)&& isDragging == false)
        {

            rectTransform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 90);
            rotation += 90;
            if (rotation >= 360)
            {
                rotation = 0;
            }
            RotateConnectionPoints();
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = false;
        CurrentDragDrop = this;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {

            rectTransform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 90);
            rotation += 90;
            if (rotation >= 360)
            {
                rotation = 0;
            }
            RotateConnectionPoints();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDragging= false;
        rectTransform.anchoredPosition += eventData.delta/ canvas.scaleFactor;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            rectTransform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 90);
            rotation += 90;
            if(rotation>= 360)
            {
                rotation = 0;
            }
            RotateConnectionPoints();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = true;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            RotateConnectionPoints();
            rectTransform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 90);
            rotation += 90;
        }*/
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
        
    }

    public void ResetTheGame()
    {
        RoadToCheckpoint = new List<DragDrop>();
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
            switch (rotation)
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
                case 180:
                    leftConnect = true;
                    rightConnect = false;
                    bottomConnect = false;
                    topConnect = true;
                    break;
                case 270:
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
