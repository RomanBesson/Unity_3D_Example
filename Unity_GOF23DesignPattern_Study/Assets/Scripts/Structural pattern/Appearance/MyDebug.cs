using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 一键控制所有报错信息的显示
/// </summary>
public class MyDebug {

    private static bool state = true;

    public static void Log(object message)
    {
        if (state)
        {
            Debug.Log(message);
        }
    }

    public static void LogWarning(object message)
    {
        if(state)
        {
            Debug.LogWarning(message);
        }
    }

    public static void LogError(object message)
    {
        if (state)
        {
            Debug.LogError(message);
        }
    }
}
