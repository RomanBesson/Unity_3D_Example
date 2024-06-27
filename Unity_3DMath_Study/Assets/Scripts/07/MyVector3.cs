using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector3 {

    public float x;
    public float y;
    public float z;

    public MyVector3() { }
    public MyVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static MyVector3 up
    {
        get { return new MyVector3(0, 1, 0); }
    }

    public static MyVector3 right
    {
        get { return new MyVector3(1, 0, 0); }
    }

    public static MyVector3 zero
    {
        get { return new MyVector3(0, 0, 0); }
    }

    public float magnitude
    {
        get
        {
            float tempX = this.x * this.x;
            float tempY = this.y * this.y;
            float tempZ = this.z * this.z;
            return Mathf.Sqrt(tempX + tempY + tempZ);
        }
    }

    public MyVector3 normalized
    {
        get
        {
            float temp = this.magnitude;
            float tempX = this.x / temp;
            float tempY = this.y / temp;
            float tempZ = this.z / temp;
            return new MyVector3(tempX, tempY, tempZ);
        }
    }

    public static float Distance(MyVector3 v1, MyVector3 v2)
    {
        MyVector3 temp = v1 - v2;
        return temp.magnitude;
    }

    public static float Dot(MyVector3 v1, MyVector3 v2)
    {
        return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
    }

    public static MyVector3 operator -(MyVector3 a)
    {
        return new MyVector3(-a.x, -a.y, -a.z);
    }

    public static MyVector3 operator *(float a, MyVector3 b)
    {
        return new MyVector3(a * b.x, a * b.y, a * b.z);
    }

    public static MyVector3 operator +(MyVector3 a, MyVector3 b)
    {
        return new MyVector3(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static MyVector3 operator -(MyVector3 a, MyVector3 b)
    {
        return new MyVector3(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public override string ToString()
    {
        return string.Format("({0}, {1}, {2})", this.x, this.y, this.z);
    }
}
