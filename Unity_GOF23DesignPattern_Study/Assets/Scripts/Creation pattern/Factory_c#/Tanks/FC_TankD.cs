using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FC_TankD : FC_TankBase
{

    public FC_TankD(int speed, int life) : base(speed, life) { }

    public override void TankShoot()
    {
        Debug.Log("一次发射四枚炮弹.");
    }
}

