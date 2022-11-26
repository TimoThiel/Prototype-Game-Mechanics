using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    private List<GameObject> tiles = new List<GameObject>();

    [SerializeField] private GameObject obj;

    public TextMeshProUGUI geld;
    public TextMeshProUGUI rotondeAmount;
    public TextMeshProUGUI waveAmount;
    public int money;
    public int rotondes;
    public int waves;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void ChangeAmount(int text)
    {
        this.money += text;
    }
    public void ChangeRotondeAmount(int text)
    {
        this.rotondes += text;
    }
    public void ChangeWaveAmount(int text)
    {
        this.waves += text;
    }
    // Update is called once per frame
    void Update()
    {
        geld.text = "Money: " + money.ToString();
        rotondeAmount.text = "rotondes: " + rotondes.ToString();
        waveAmount.text = "wave: " + waves.ToString();
    }
}
