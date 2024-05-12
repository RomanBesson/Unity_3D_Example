using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankB : TankBase
{

    public TankB(int speed, int life) : base(speed, life) { }

    public override void TankShoot()
    {
        Debug.Log("一次发射两枚炮弹.");
    }
}

