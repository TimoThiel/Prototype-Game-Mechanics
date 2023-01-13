using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTile : test
{
    [SerializeField] private Color firstColor, secondColor;
    // Start is called before the first frame update
    public override void Init(int x, int y)
    {
        base.Init(6, 5);
        renderer.color = secondColor;
    }
}
