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
    public bool isSelected = false;
    public bool topConnect, leftConnect, rightConnect, bottomConnect;
    [SerializeField] private bool isCorner, isRight;
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
        else if(isRight)
        {
            leftConnect = true; 
            rightConnect = true; 
            bottomConnect =false; 
            topConnect = false;
        }
        else
        {
            leftConnect = true;
            rightConnect = true;
            bottomConnect = true;
            topConnect = true;
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
        if (Input.GetKeyDown(KeyCode.Space) && !isDragging && isSelected)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, rotation + 90f);
            StartCoroutine(RotatePiece(targetRotation));
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        isSelected = true;
        isDragging = false;
        CurrentDragDrop = this;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
      
    }

    public void OnDrag(PointerEventData eventData)
    {
        isSelected = true;
        isDragging = false;
        rectTransform.anchoredPosition += eventData.delta/ canvas.scaleFactor;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isSelected = true;
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
    private IEnumerator RotatePiece(Quaternion targetRotation)
    {
        const float rotationDuration = 0.3f; // Duur van de rotatie (in seconden)
        float elapsedTime = 0f;
        Quaternion startRotation = rectTransform.rotation;

        while (elapsedTime < rotationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / rotationDuration);
            rectTransform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
            yield return null;
        }

        rectTransform.rotation = targetRotation; // Zorg ervoor dat de rotatie exact de doelrotatie is
        rotation += 90;
        if (rotation >= 360f)
        {
            rotation = 0;
        }

       /* RotateConnectionPoints();*/
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
/*    void RotateConnectionPoints()
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
        else if (isRight)
        {
            bool temp = leftConnect;
            leftConnect = rightConnect;
            rightConnect = temp;
            temp = bottomConnect;
            bottomConnect = topConnect;
            topConnect = temp;
        }
        else
        {
            leftConnect = !leftConnect;
            rightConnect = !rightConnect;
            bottomConnect = !bottomConnect;
            topConnect = !topConnect;
        }
    }
*/
}
