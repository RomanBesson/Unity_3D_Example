using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person {

    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    //public static 返回值类型 operator 运算符（参数列表）{ }
    //public static Person operator +(Person pA, Person pB) { }

    public static int operator +(Person p1, Person p2)
    {
        return p1.Age + p2.Age;
    }

}
