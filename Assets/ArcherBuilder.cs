using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ArcherBuilder : MonoBehaviour
{

    [SerializeField] public Transform tile;
    [SerializeField] private WaveSpwner waveSpwner;
    public Vector2 positionPrevius = new Vector2();
    private List<GameObject> tiles = new List<GameObject>();
    private List<GameObject> traps = new List<GameObject>();
    private List<GameObject> water = new List<GameObject>();
    private List<GameObject> elek = new List<GameObject>();
    [SerializeField] private GameObject obj;
    [SerializeField] private GameObject trp;
    [SerializeField] private GameObject wtr;
    [SerializeField] private GameObject ele;
    public int beginTile = 0;
    public int maxTiles = 10;
    public int beginTrap = 0;
    public int maxTraps = 5;
    public int beginWater = 0;
    public int maxWater = 5;
    public int beginele = 0;
    public int maxele = 5;

   [SerializeField] private int placedTurrets = 0;
   [SerializeField] private GameObject floatingTextPrefab;
   
    void Update()
    {
/*        obj.SetActive(true);
        if (Input.GetMouseButtonDown(0) && beginTile < maxTiles)
        {
            beginTile++;
            placedTurrets++;
            ShowAmount(placedTurrets.ToString());
            *//*Debug.Log("Amount placed:"+ placedTurrets);*//*
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 2.0f;       // we want 2m away from the camera position
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            tiles.Add(Instantiate(obj, objectPos, Quaternion.identity));
        }
       
        if(Input.GetMouseButtonDown(0) && beginTile == maxTiles && beginTrap < maxTraps && waveSpwner.waveNumber >= 3)
        {
            beginTrap++;
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 2.0f;       // we want 2m away from the camera position
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            traps.Add(Instantiate(trp, objectPos, Quaternion.identity));
        }

        if (Input.GetMouseButtonDown(0) && beginTile == maxTiles && beginTrap == maxTraps && beginWater < maxWater && waveSpwner.waveNumber >= 8)
        {
            beginWater++;
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 2.0f;       // we want 2m away from the camera position
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            water.Add(Instantiate(wtr, objectPos, Quaternion.identity));
        }

        if (Input.GetMouseButtonDown(0) && beginTile == maxTiles && beginTrap == maxTraps && beginWater == maxWater && beginele < maxele && waveSpwner.waveNumber >= 15)
        {
            beginele++;
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 2.0f;       // we want 2m away from the camera position
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            elek.Add(Instantiate(ele, objectPos, Quaternion.identity));*/
       /* }*/

    }

    void ShowAmount(string text)
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position,Quaternion.identity);
            prefab.GetComponent<TextMesh>().text = text;
            prefab.transform.position = new Vector2(9.88f, -3.47f);
        }
    }
}
 