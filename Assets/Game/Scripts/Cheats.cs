/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    public GameManage gameManager;
    [SerializeField] public Mover move;
    [SerializeField] public EnemySlower web;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            move.currentSpeed *= 1.01f;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            gameManager.ChangeAmount(100);
        }

    }
}
*/