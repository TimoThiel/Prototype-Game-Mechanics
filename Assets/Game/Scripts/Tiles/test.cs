using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
 [SerializeField] private Color firstColor, secondColor;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private GameObject highlight;

    public void Init(bool isOffset)
    {
        renderer.color = isOffset ? secondColor : firstColor;
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
