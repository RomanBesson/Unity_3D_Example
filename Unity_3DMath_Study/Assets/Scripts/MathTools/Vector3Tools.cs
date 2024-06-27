using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Vector3工具类.
/// </summary>
public static class Vector3Tools {

    /// <summary>
    /// 计算两个Vector3之间的距离.
    /// Vector3.Distance(v1, v2);
    /// </summary>
    public static float Distance(Vector3 v1, Vector3 v2)
    {
        return (v2 - v1).magnitude;
    }

    /// <summary>
    /// 向量点乘.
    /// Vector3.Dot(v1, v2);
    /// </summary>
    public static float Dot(Vector3 v1, Vector3 v2)
    {
        return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
    }

    /// <summary>
    /// 向量点乘--几何方式.
    /// Vector3.Dot(v1, v2);
    /// </summary>
    public static float DotByGemo(Vector3 v1, Vector3 v2)
    {
        //先得到弧度值.
        float radian = Radian(v1, v2);
        return v1.magnitude * v2.magnitude * Mathf.Cos(radian);
    }

    /// <summary>
    /// 向量叉乘.
    /// </summary>
    public static Vector3 Cross(Vector3 v1, Vector3 v2)
    {
        float x = v1.y * v2.z - v1.z * v2.y;
        float y = v1.z * v2.x - v1.x * v2.z;
        float z = v1.x * v2.y - v1.y * v2.x;
        return new Vector3(x, y, z);
    }

    /// <summary>
    /// 计算两个向量之间夹角的角度.
    /// Vector3.Angle(v1, v2);
    /// </summary>
    public static float Angle(Vector3 v1, Vector3 v2)
    {
        //先得到弧度值.
        float radian = Radian(v1, v2);
        //弧度转角度.
        return radian * 180 / Mathf.PI; ;
    }

    /// <summary>
    /// 计算两个向量之间夹角的弧度.
    /// </summary>
    public static float Radian(Vector3 v1, Vector3 v2)
    {
        //向量点乘.
        float dot = Vector3.Dot(v1, v2);
        //向量取模,然后相乘.
        float num1 = v1.magnitude * v2.magnitude;
        //得到一个弧度.
        return Mathf.Acos(dot / num1);
    }

    /// <summary>
    /// 求叉乘结果的模.
    /// </summary>
    public static float CrossGetMagnitude(Vector3 v1, Vector3 v2)
    {
        return v1.magnitude * v2.magnitude * Mathf.Sin(Radian(v1, v2));
    }

    /// <summary>
    /// 计算向量投影.
    /// Vector3.Project(v1, v2);
    /// </summary>
    public static Vector3 Project(Vector3 v1, Vector3 v2)
    {
        //先得到弧度值.
        float radian = Radian(v1, v2);
        //求向量b平行分量的模.
        float num = Mathf.Cos(radian) * v1.magnitude;
        //求向量b相对于向量a的平行分量，也就是投影.
        return (num / v2.magnitude) * v2;
    }

}
