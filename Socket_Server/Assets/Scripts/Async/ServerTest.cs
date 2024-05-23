using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerTest : MonoBehaviour {

    private MKAsyncServer serverSocket;

	void Start () {
        serverSocket = MKAsyncServer.Instance;
	}
	
	void Update () {
        SendTest();
	}

    /// <summary>
    /// 消息发送测试方法.
    /// </summary>
    private void SendTest()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            serverSocket.SendAll();
        }
    }

}
