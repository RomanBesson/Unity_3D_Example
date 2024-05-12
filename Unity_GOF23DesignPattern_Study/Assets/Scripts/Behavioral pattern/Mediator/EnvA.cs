using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvA : MonoBehaviour {

    private int HP = 100;

    public void DamageA(int value)
    {
        HP -= value;
        Debug.Log("障碍物A的剩余生命值：" + HP);
    }
}
