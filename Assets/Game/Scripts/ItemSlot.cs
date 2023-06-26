using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour,IDropHandler
{
    [field:SerializeField] public int time { get; set; }
    [field: SerializeField] public int brug { get; set; }
    [field:SerializeField] public int points { get; set; }
    [field: SerializeField] public int points2 { get; set; }

    [field: SerializeField] public int points3 { get; set; }
    [field: SerializeField] public int money { get; set; }
    [SerializeField] private GameManages gameManages;
    [SerializeField] private AudioSource placeSound, placementsound;
    [SerializeField] private DragDrop dragDrop;
    [SerializeField] private BridgeController bridgeController;
    

    
    private void Awake()
    {
        bridgeController.isBridgeBuilt = false;// Stel de startwaarde van brug in op 0
    }


    public void OnDrop(PointerEventData eventData)
    {
        dragDrop.isDragging = true;
        Debug.Log("OnDrop");
        if(eventData.pointerDrag != null && gameManages.money > 0)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            DragDrop.RoadToCheckpoint.Add(DragDrop.CurrentDragDrop);
            gameManages.ChangeMoney(-5);
            gameManages.ChangeBocht(-1);
            Finish.points += points;
            Finish.pointsLevel2 += points2;
            Finish.pointsLevel3 += points3;
            Finish.time+= time;
            Finish.brug += brug;
            gameManages.money += money;
            placeSound.Play();
            placementsound.Play();
        }
        gameManages.ChangePunten(points);
        gameManages.ChangePunten(points2);
        gameManages.ChangePunten(points3);
        gameManages.ChangeTijd(time);
        if (brug == 1)
        {

            bridgeController.BuildBridge();
        }
    }


}
