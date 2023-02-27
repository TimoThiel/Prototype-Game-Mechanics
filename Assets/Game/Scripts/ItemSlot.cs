using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour,IDropHandler
{
    [field:SerializeField] public int points { get; set; }
    [field: SerializeField] public int points2 { get; set; }
    [SerializeField] private GameManages gameManages;
     void Start()
    {
       
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            DragDrop.RoadToCheckpoint.Add(DragDrop.CurrentDragDrop);
            Finish.points += points;
            Finish.pointsLevel2 += points2;
        }
        gameManages.ChangePunten(points);
        gameManages.ChangePunten(points2);

    }


}
