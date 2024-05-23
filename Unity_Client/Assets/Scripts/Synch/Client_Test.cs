using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class Client_Test : MonoBehaviour
{

    private string ip = "192.168.124.7";
    private int port = 33333;

    private Socket socket;
    private string friend;

    void Start()
    {
        try
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address = IPAddress.Parse(ip);
            IPEndPoint point = new IPEndPoint(address, port);

            //连接服务器Socket.
            socket.Connect(point);
        }
        catch
        {
            //服务器端的异常:记录日志;
            //客户端的异常:弹窗口给用户一个提示.
            Debug.Log("连接服务器失败.");
        }

        //开启子线程.
        Thread receiveThread = new Thread(ReceiveThread);
        receiveThread.Start();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SendMessage("log|A");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SendMessage("log|Monkey");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SendMessage("log|各位网友大家晚上好,我是Monkey!");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //“friendinfo|”+ friend + “*你好啊”
            SendMessage("friendinfo|" + friend + "*我很好,你也好啊！！");
        }


        if (Input.GetKeyDown(KeyCode.X))
        {
            Close();
            socket.Close();
            Debug.Log("客户端已经下线.");
        }
    }

    void OnDestroy()
    {
        Close();
        socket.Close();
        Debug.Log("客户端已经下线.");
    }

    /// <summary>
    /// 往服务器端发送消息.
    /// </summary>
    private void SendMessage(string text)
    {
        //将要发送的数据转码为UTF8格式的字节数组.
        byte[] message = Encoding.UTF8.GetBytes(text);
        //发送数据.
        socket.Send(message);
    }

    /// <summary>
    /// 子线程.用于接收服务器端发送过来的消息.
    /// </summary>
    private void ReceiveThread()
    {
        while (true)
        {
            byte[] message = new byte[1024];
            int length = socket.Receive(message);
            if (length == 0) break;
            string str = Encoding.UTF8.GetString(message, 0, length);
            //Debug.Log(str);        

            //第二版消息处理.
            if (str.Contains("|"))
            {
                string[] info = str.Split('|');
                //Debug.Log("消息头:" + info[0]);
                //Debug.Log("消息体:" + info[1]);
                if (info[0] == "serverlog")
                {
                    Debug.Log(info[1]);
                }
                else if (info[0] == "friendonline")
                {
                    friend = info[1];
                    Debug.Log(info[1]);
                }

            }

        }
    }

    /// <summary>
    /// 关闭客户端.
    /// </summary>
    private void Close()
    {
        SendMessage("CLOSE");
    }
}
