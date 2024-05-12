using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvB : MonoBehaviour {

    private int HP = 100;

    public void DamageB(int value)
    {
        HP -= value;
        Debug.Log("障碍物B的剩余生命值：" + HP);
    }
}
