using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class test : MonoBehaviour
{
 
    [SerializeField] protected SpriteRenderer renderer;
    [SerializeField] private GameObject highlight;

    public virtual void Init(int x,int y)
    {
        
    }

     void OnMouseEnter()
    {
        highlight.SetActive(true);
    }
     void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
