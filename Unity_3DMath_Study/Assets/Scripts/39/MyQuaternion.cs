using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自定义四元数类.
/// </summary>
public class MyQuaternion {

    public float x;
    public float y;
    public float z;
    public float w;

    public float Magnitude
    {
        get
        {
            return Mathf.Sqrt(x * x + y * y + z * z + w * w);
        }
    }


    public static MyQuaternion Identity
    {
        get
        {
            return new MyQuaternion(0, 0, 0, 1);
        }
    }

    public MyQuaternion() { }
    public MyQuaternion(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }


    public static MyQuaternion ToQuaternion(float deg, Vector3 axis)
    {
        float rad = (deg * 0.5f) * Mathf.Deg2Rad;
        float x = Mathf.Sin(rad) * axis.x;
        float y = Mathf.Sin(rad) * axis.y;
        float z = Mathf.Sin(rad) * axis.z;
        float w = Mathf.Cos(rad);
        return new MyQuaternion(x, y, z, w);
    }

    public float GetAngle()
    {
        return (Mathf.Acos(w) * Mathf.Rad2Deg) * 2;
    }

    public Vector3 GetAxis()
    {
        float rad = (GetAngle() * 0.5f) * Mathf.Deg2Rad;
        float temp = Mathf.Sin(rad);
        return new Vector3(x / temp, y /temp, z / temp);
    }

    public static float Dot(MyQuaternion q1, MyQuaternion q2)
    {
        return q1.x * q2.x + q1.y * q2.y + q1.z * q2.z + q1.w * q2.w;
    }

    public static MyQuaternion operator *(MyQuaternion q1, MyQuaternion q2)
    {
        return new MyQuaternion(
            q1.w * q2.x + q2.w * q1.x + q1.y * q2.z - q1.z * q2.y,
            q1.w * q2.y + q2.w * q1.y + q1.z * q2.x - q1.x * q2.z,
            q1.w * q2.z + q2.w * q1.z + q1.x * q2.y - q1.y * q2.x, 
            q1.w * q2.w - q1.x * q2.x - q1.y * q2.y - q1.z * q2.z
        );
    }

    public static MyQuaternion Euler(Vector3 v)
    {
        MyQuaternion mqx = ToQuaternion(v.x, Vector3.right);
        MyQuaternion mqy = ToQuaternion(v.y, Vector3.up);
        MyQuaternion mqz = ToQuaternion(v.z, Vector3.forward);
        MyQuaternion mq = mqy * mqx * mqz;
        return mq;
    }

    public static MyQuaternion Inverse(MyQuaternion mq)
    {
        return new MyQuaternion(-mq.x, -mq.y, -mq.z, mq.w);
    }

    public static MyQuaternion NewEuler(Vector3 v)
    {
        float x = (v.x * 0.5f) * Mathf.Deg2Rad;
        float y = (v.y * 0.5f) * Mathf.Deg2Rad;
        float z = (v.z * 0.5f) * Mathf.Deg2Rad;

        float mqx = Mathf.Cos(y) * Mathf.Sin(x) * Mathf.Cos(z) +
            Mathf.Sin(y) * Mathf.Cos(x) * Mathf.Sin(z);

        float mqy = Mathf.Sin(y) * Mathf.Cos(x) * Mathf.Cos(z) -
            Mathf.Cos(y) * Mathf.Sin(x) * Mathf.Sin(z);

        float mqz = Mathf.Cos(y) * Mathf.Cos(x) * Mathf.Sin(z) -
            Mathf.Sin(y) * Mathf.Sin(x) * Mathf.Cos(z);

        float mqw = Mathf.Cos(y) * Mathf.Cos(x) * Mathf.Cos(z) +
            Mathf.Sin(y) * Mathf.Sin(x) * Mathf.Sin(z);

        return new MyQuaternion(mqx, mqy, mqz, mqw);
    }

    public override string ToString()
    {
        return string.Format("({0}, {1}, {2}, {3})", this.x, this.y, this.z, this.w);
    }


}
