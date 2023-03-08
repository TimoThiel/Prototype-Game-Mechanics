using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManages : MonoBehaviour
{
    [SerializeField] public MoveTruck move;
    public TextMeshProUGUI tijdMeter, puntenMeter, moneyMeter;
    public int money, punten, tijd;
    public float tijdCount, puntCount,moneyCount;
    private void Awake()
    {
        money = 50;
        tijd = 35;
        if (tijdCount < 1)
        {
            /*ChangeTijd(-1);*/
            tijdCount = 0;
        }
        tijdCount += Time.deltaTime;
    }
    public void ChangeTijd(int text)
    {
        this.tijd += text;
       
    }
    public void ChangeMoney(int text)
    {
        this.money += text;
       
    }
    public void ChangePunten(int text)
    {
        this.punten += text;
    }

    void Update()
    {
        tijdMeter.text = "Tijd: " + tijd.ToString();
        moneyMeter.text = "Money: " + money.ToString();
        puntenMeter.text = "Punten: "+ punten.ToString() + " If 2 finish";

        if (tijd <= 0)
        {
            ResetTheGame();
        }

    }

    public void ResetTheGame()
    {
        DragDrop.RoadToCheckpoint = new List<DragDrop>();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Finish.busReachEnd = false;
        Finish.points = 0;
    }
}
