using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tower : MonoBehaviour
{
    int health;
    public GameObject explo;
    [SerializeField] public int maxHitBox = 100;
    [SerializeField] private GameObject floatingTextPrefab;
    private GameObject floatingText;
    [SerializeField] private GameObject enemie;
    public Enemy enem;
    
    private void Start()
    {
        floatingText = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
        health = maxHitBox;
            ShowAmount(health.ToString());
    }
    private void Update()
    {
        if (health <= 0)
        {
            ResetTheGame();
            
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HitTower();
            Explosion();
            
        }
        
    }
    public void Explosion()
    {
        GameObject obj = Instantiate(explo, transform);
        obj.transform.parent = null;
        obj.transform.position = transform.position;
    }
   

        public void HitTower()
    {
        
        health -= 10;
        ShowAmount(health.ToString());
        
    }

    void ShowAmount(string text)
    {
        if (floatingTextPrefab)
        {
            floatingText.GetComponent<TextMesh>().text = text;
            floatingText.transform.position = new Vector2(10f, 1.5f);
        }
    }
    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
