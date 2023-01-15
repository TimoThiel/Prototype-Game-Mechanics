using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform currentItem;
   
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


}
