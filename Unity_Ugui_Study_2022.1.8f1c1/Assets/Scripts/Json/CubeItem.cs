using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 实体类，用于储存位置
/// </summary>
public class CubeItem {

    private string posX;
    private string posY;
    private string posZ;

    public string PosX
    {
        get { return posX; }
        set { posX = value; }
    }

    public string PosY
    {
        get { return posY; }
        set { posY = value; }
    }

    public string PosZ
    {
        get { return posZ; }
        set { posZ = value; }
    }

    public CubeItem() { }
    public CubeItem(string x, string y, string z)
    {
        this.posX = x;
        this.posY = y;
        this.posZ = z;
    }

    public override string ToString()
    {
        return string.Format("X:{0} Y:{1} Z:{2}", this.posX, this.posY, this.posZ);
    }
}
