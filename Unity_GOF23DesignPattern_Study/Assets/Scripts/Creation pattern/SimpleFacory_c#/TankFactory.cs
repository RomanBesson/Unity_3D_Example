using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 工厂方法，用于创建坦克
/// </summary>
public class TankFactory
{

    public static TankBase CreateTank(string tankName)
    {
        TankBase tankBase = null;
        switch (tankName)
        {
            case "TankA":
                tankBase = new TankA(2, 100);
                break;
            case "TankB":
                tankBase = new TankB(4, 200);
                break;
            case "TankC":
                tankBase = new TankC(6, 300);
                break;
        }
        return tankBase;
    }


}
