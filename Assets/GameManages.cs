using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManages : MonoBehaviour
{
    [SerializeField] public moveTruck move;
    public TextMeshProUGUI AngryMeter;
    public int angry;
    private void Awake()
    {
        angry = 0;
    }
    public void ChangeAngryMeter(int text)
    {
        this.angry += text;
    }

    void Update()
    {
      
        AngryMeter.text = "Angry: " + angry.ToString();

        if (angry >= 100)
        {
            ResetTheGame();
        }
        

    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
