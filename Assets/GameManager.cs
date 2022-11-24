using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public TextMeshProUGUI geld;
    public int money;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChangeAmount(int text)
    {
        this.money += text;
    }
    // Update is called once per frame
    void Update()
    {
        geld.text = money.ToString();
    }
}
