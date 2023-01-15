using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    [SerializeField] private GameObject car;
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    
   
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup= GetComponent<CanvasGroup>();
        
    }
    public void Update()
    {
      if(Input.GetKeyDown(KeyCode.R))
        {
            ResetTheGame();
        }
        if(Input.GetKeyDown(KeyCode.D))
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
        Instantiate(car, new Vector3(0,0), Quaternion.Euler(0f, 0f, 0f));
    }
    void MoveCar()
    {
        
    }


}
