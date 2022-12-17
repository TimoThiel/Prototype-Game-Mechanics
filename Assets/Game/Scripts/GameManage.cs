using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    private List<GameObject> tiles = new List<GameObject>();

    [SerializeField] private GameObject obj;

    public TextMeshProUGUI geld;
    public TextMeshProUGUI waveAmount;
    public int money;
    public int waves;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void ChangeAmount(int text)
    {
        this.money += text;
    }

    public void ChangeWaveAmount(int text)
    {
        this.waves += text;
    }
    // Update is called once per frame
    void Update()
    {
        geld.text = "Money: " + money.ToString();
        waveAmount.text = "wave: " + waves.ToString();
    }
}
