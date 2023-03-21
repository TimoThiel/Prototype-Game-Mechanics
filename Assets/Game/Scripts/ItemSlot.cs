using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour,IDropHandler
{
    [field:SerializeField] public int points { get; set; }
    [field: SerializeField] public int points2 { get; set; }

    [field: SerializeField] public int points3 { get; set; }
    [field: SerializeField] public int money { get; set; }
    [SerializeField] private GameManages gameManages;
    [SerializeField] private AudioSource placeSound, placementsound;
     void Start()
    {
       
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if(eventData.pointerDrag != null && gameManages.money >= 0)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            DragDrop.RoadToCheckpoint.Add(DragDrop.CurrentDragDrop);
            gameManages.ChangeMoney(-5);
            gameManages.ChangeBocht(-1);
            Finish.points += points;
            Finish.pointsLevel2 += points2;
            Finish.pointsLevel3 += points3;
            gameManages.money += money;
            placeSound.Play();
            placementsound.Play();
        }
        gameManages.ChangePunten(points);
        gameManages.ChangePunten(points2);
        gameManages.ChangePunten(points3);

    }


}
