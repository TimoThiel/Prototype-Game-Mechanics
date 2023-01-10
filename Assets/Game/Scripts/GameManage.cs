using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    private List<GameObject> tiles = new List<GameObject>();

    [SerializeField] private GameObject obj;

    public TextMeshProUGUI geld;
    public TextMeshProUGUI waveAmount;
    public TextMeshProUGUI AngryMeter;
    public int money;
    public int waves;
    public int angry;

    // Start is called before the first frame update
    void Start()
    {
        /*Angry = 0;*/
    }
    public void ChangeAmount(int text)
    {
        this.money += text;
    }

    public void ChangeWaveAmount(int text)
    {
        this.waves += text;
    }

    public void ChangeAngryMeter(int text)
    {
        this.angry += text;
    }

    // Update is called once per frame
    void Update()
    {
        geld.text = "Money: " + money.ToString();
        waveAmount.text = "wave: " + waves.ToString();
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
