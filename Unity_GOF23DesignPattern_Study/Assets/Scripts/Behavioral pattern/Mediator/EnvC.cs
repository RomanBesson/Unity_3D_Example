using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvC : MonoBehaviour {

    private int HP = 100;

    public void DamageC(int value)
    {
        HP -= value;
        Debug.Log("障碍物C的剩余生命值：" + HP);
    }
}
