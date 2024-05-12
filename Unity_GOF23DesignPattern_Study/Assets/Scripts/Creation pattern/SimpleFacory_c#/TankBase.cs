using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 坦克个体的基类
/// </summary>
public class TankBase
{
    //坦克移动速度
    private int moveSpeed;
    //生命值
    private int lifeValue;

    public int MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    public int LifeValue
    {
        get { return lifeValue; }
        set { lifeValue = value; }
    }

    public TankBase(int speed, int life)
    {
        this.moveSpeed = speed;
        this.lifeValue = life;
    }

    public virtual void TankMove()
    {
        Debug.Log("坦克移动");
    }

    public virtual void TankShoot()
    {
        Debug.Log("坦克射击");
    }

    public override string ToString()
    {
        return string.Format("移动速度:{0}, 生命值:{1}", this.moveSpeed, this.lifeValue);
    }
}
