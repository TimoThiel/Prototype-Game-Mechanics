using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManages : MonoBehaviour
{
    [SerializeField] public MoveTruck move;
    public TextMeshProUGUI tijdMeter, puntenMeter;
    public int tijd, punten;
    public float tijdCount, puntCount;
    private void Awake()
    {
        tijd = 35;
        if (tijdCount < 0)
        {

            ChangeTijd(-1);
            tijdCount = 1;
        }
        tijdCount -= Time.deltaTime;
    }
    public void ChangeTijd(int text)
    {
        this.tijd += text;
       
    }
    public void ChangePunten(int text)
    {
        this.punten += text;
    }

    void Update()
    {
      
        tijdMeter.text = "Tijd: " + tijd.ToString();
        puntenMeter.text = "Punten: "+ punten.ToString() + " If 2 finish";

        if (tijd <= 0)
        {
            ResetTheGame();
        }

    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Finish.busReachEnd = false;
        Finish.points = 0;
    }
}
