using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person {

    private string name;
    private int age;
    private string address;

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

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    public Person() { }
    public Person(string name, int age, string address)
    {
        this.name = name;
        this.age = age;
        this.address = address;
    }

    public override string ToString()
    {
        return string.Format("姓名:{0}, 年龄:{1}, 地址:{2}", this.name, this.age, this.address);
    }
}
