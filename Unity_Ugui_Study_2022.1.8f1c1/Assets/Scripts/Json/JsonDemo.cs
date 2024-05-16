using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class JsonDemo : MonoBehaviour {

    private List<Person> personListOne;

	void Start () {
        personListOne = new List<Person>();

        Person p1 = new Person("Monkey", 100, "BeiJing");
        Person p2 = new Person("LKK", 50, "ShanDong");
        Person p3 = new Person("MKCODE", 1, "ZhongGuo");
        personListOne.Add(p1);
        personListOne.Add(p2);
        personListOne.Add(p3);

        //string转json
        string jsonStr = JsonMapper.ToJson(p1);
        Debug.Log(jsonStr);

        //json转换成object
        Person p4 = JsonMapper.ToObject<Person>(jsonStr);
        Debug.Log(p4.ToString());


        jsonStr = JsonMapper.ToJson(personListOne);
        Debug.Log(jsonStr);
    }
	
}
