using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankA : TankBase
{

    public TankA(int speed, int life) : base(speed, life) { }

    public override void TankShoot()
    {
        Debug.Log("一次发射一枚炮弹.");
    }
}
