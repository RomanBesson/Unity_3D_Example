using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FC_TankBase
{

    private int moveSpeed;
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

    public FC_TankBase(int speed, int life)
    {
        this.moveSpeed = speed;
        this.lifeValue = life;
    }

    public virtual void TankMove()
    {
        Debug.Log("̹���ƶ�");
    }

    public virtual void TankShoot()
    {
        Debug.Log("̹�����");
    }

    public override string ToString()
    {
        return string.Format("�ƶ��ٶ�:{0}, ����ֵ:{1}", this.moveSpeed, this.lifeValue);
    }
}
