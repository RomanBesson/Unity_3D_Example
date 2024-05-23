using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SocketDLL;

public class ClientTest : MonoBehaviour {

    private MKAsyncClient clientSocket;

	void Start () {
        clientSocket = MKAsyncClient.Instance;

        //对象初始化.
        Person person = new Person();
        person.Name = "Monkey";
        person.Age = 31;

        //对象序列化.
        byte[] tempByte = SocketTools.Serialize(person);

        //遍历查看byte数组.
        string tempStr = null;
        for (int i = 0; i < tempByte.Length; i++)
        {
            tempStr += tempByte[i];
            tempStr += ",";
        }
        //Debug.Log("数据长度:" + tempByte.Length + "数据内容:" + tempStr);


        //对象反序列化.
        Person p = (Person)SocketTools.Deserialize(tempByte);
        //Debug.Log("P.Name:" + p.Name);
        //Debug.Log("p.Age:" + p.Age);

	}
	

	void Update () {
        SendTest();
	}

    private void TestSend()
    {
        //对象初始化.
        Person person = new Person();
        person.Name = "MKCODE";
        person.Age = 4;
        //数据封装.
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.TestA;
        message.Body = person;
        //序列化.
        byte[] bytes = SocketTools.Serialize(message);
        //发送.
        clientSocket.Send(bytes);
        //遍历查看byte数组.
        string tempStr = null;
        for (int i = 0; i < bytes.Length; i++)
        {
            tempStr += bytes[i];
            tempStr += ",";
        }
        Debug.Log("数据长度:" + bytes.Length + "数据内容:" + tempStr);
    }

    /// <summary>
    /// 消息发送测试方法.
    /// </summary>
    private void SendTest()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    clientSocket.StartClient();
        //}
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    TestSend();
        //}
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    clientSocket.ResetConnect();
        //}
    }



}
