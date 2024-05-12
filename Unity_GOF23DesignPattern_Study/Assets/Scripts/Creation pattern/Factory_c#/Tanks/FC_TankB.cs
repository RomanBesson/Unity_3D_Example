using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FC_TankB : FC_TankBase
{

    public FC_TankB(int speed, int life) : base(speed, life) { }

    public override void TankShoot()
    {
        Debug.Log("一次发射二枚炮弹.");
    }
}

