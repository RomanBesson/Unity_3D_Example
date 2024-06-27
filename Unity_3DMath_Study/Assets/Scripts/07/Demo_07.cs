using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_07 : MonoBehaviour {

    private Vector3 cube1;
    private Vector3 cube2;

	void Start () {
        //得到两个角色的位置.
        cube1 = GameObject.Find("Cube1").GetComponent<Transform>().position;
        cube2 = GameObject.Find("Cube2").GetComponent<Transform>().position;

        Debug.Log("Vector3.Distance:" + Vector3.Distance(cube1, cube2));
        Debug.Log("Vector3Tools.Distance:" + Vector3Tools.Distance(cube1, cube2));

        Debug.Log("Vector3.Dot:" + Vector3.Dot(cube1, cube2));
        Debug.Log("Vector3Tools.Dot:" + Vector3Tools.Dot(cube1, cube2));
        Debug.Log("Vector3Tools.DotByGemo:" + Vector3Tools.DotByGemo(cube1, cube2));

        Debug.Log("Vector3.Angle:" + Vector3.Angle(cube1, cube2));
        Debug.Log("Vector3Tools.Angle:" + Vector3Tools.Angle(cube1, cube2));

        Debug.Log("Vector3.Project:" + Vector3.Project(cube1, cube2));
        Debug.Log("Vector3Tools.Project:" + Vector3Tools.Project(cube1, cube2));

        Debug.Log("Vector3.Cross:" + Vector3.Cross(cube1, cube2));
        Debug.Log("Vector3Tools.Cross:" + Vector3Tools.Cross(cube1, cube2));


        Debug.Log("Vector3实现求叉乘结果的模:" + cube1.magnitude * cube2.magnitude * Mathf.Sin(Vector3.Angle(cube1, cube2) * Mathf.Deg2Rad));
        Debug.Log("Vector3叉乘结果直接取模:" + Vector3.Cross(cube1, cube2).magnitude);
        Debug.Log("Vector3Tools.CrossGetMagnitude:" + Vector3Tools.CrossGetMagnitude(cube1, cube2));
	}
    
    private void TestVector3()
    {

        //1.分量字段与构造.
        Vector3 v1 = new Vector3(10, 10, 10);
        Debug.Log(v1.x);
        MyVector3 v2 = new MyVector3(10, 10, 10);
        Debug.Log(v2.x);
        Vector3 v3 = new Vector3(2, 3, 5);
        MyVector3 v4 = new MyVector3(2, 3, 5);

        //2.方向向量.
        Debug.Log(Vector3.up);
        Debug.Log(Vector3.right);
        Debug.Log(MyVector3.up);
        Debug.Log(MyVector3.right);

        //3.零向量.
        Debug.Log(Vector3.zero);
        Debug.Log(MyVector3.zero);

        //4.负向量.
        Debug.Log(-v1);
        Debug.Log(-v2);

        //5.向量与标量相乘.
        Debug.Log(5 * v1);
        Debug.Log(5 * v2);

        //6.向量之间的加/减法.
        Debug.Log(v1 + v1);
        Debug.Log(v2 + v2);
        Debug.Log(v1 - v1);
        Debug.Log(v2 - v2);

        //7.向量求大小/长度/模.
        Debug.Log(v3.magnitude);
        Debug.Log(v4.magnitude);

        //8.向量标准化.
        Debug.Log(v3.normalized);
        Debug.Log(v4.normalized);

        //9.向量距离.
        Debug.Log(Vector3.Distance(v1, v3));
        Debug.Log(MyVector3.Distance(v2, v4));

        //10.向量点乘.
        Debug.Log(Vector3.Dot(v1, v3));
        Debug.Log(MyVector3.Dot(v2, v4));
    }

    private void TestPerson()
    {
        Person p1 = new Person();
        p1.Name = "擅码网";
        p1.Age = 3;
        Person p2 = new Person();
        p2.Name = "李开坤";
        p2.Age = 28;

        Debug.Log(p1 + p2);
    }
}
