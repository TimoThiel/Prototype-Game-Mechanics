using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTile : test
{
    [SerializeField] private Color firstColor, secondColor;
    public override void Init(int x, int y)
    {
        var isOffset = (x + y)% 2 ==1;
        renderer.color = isOffset ? secondColor : firstColor;
    }
}
