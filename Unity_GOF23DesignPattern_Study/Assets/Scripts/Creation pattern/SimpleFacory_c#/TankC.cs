using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankC : TankBase
{

    public TankC(int speed, int life) : base(speed, life) { }

    public override void TankShoot()
    {
        Debug.Log("一次发射三枚炮弹.");
    }
}
