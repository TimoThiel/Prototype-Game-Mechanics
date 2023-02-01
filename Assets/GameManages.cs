using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManages : MonoBehaviour
{
    [SerializeField] public MoveTruck move;
    public TextMeshProUGUI tijdMeter;
    public int tijd;
    
    private void Awake()
    {
        tijd = 30;
        
    }
    public void ChangeTijd(int text)
    {
        this.tijd += text;
    }

    void Update()
    {
      
        tijdMeter.text = "Tijd: " + tijd.ToString();

        if (tijd <= 0)
        {
            ResetTheGame();
        }
        

    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
