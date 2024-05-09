using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 负责触发
/// </summary>
public class Point : MonoBehaviour
{

    public int index;

    void OnTriggerEnter(Collider coll)
    {
        object id = index;
        if (coll.name == "Player")
        {
            //销毁自身以及继续指引
            SendMessageUpwards("TriggerEnter", id);
        }
    }
}
