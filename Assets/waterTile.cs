using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterTile : test
{
    [SerializeField] private Color firstColor, secondColor;
    public override void Init(int x, int y)
    {
        base.Init(6, 5);
        renderer.color = secondColor;
    }
}
