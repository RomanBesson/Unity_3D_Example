using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1.引入相关命名空间.
using System.Net;
using System.Net.Sockets;
//引入线程相关的命名空间.
using System.Threading;
using System.Text;

public class Server_Test : MonoBehaviour
{

    //2.两个配置信息.
    private string ip;      //IP地址.
    private int port = 33333;                //端口号.

    private Socket socket;                   //主Socket对象.

    private Dictionary<string, Socket> clientDic = new Dictionary<string, Socket>();      //客户端集合.

    private void Awake()
    {
        ip = DataConfig.IP_DATA;
    }
    void Start()
    {
        Socket_Init();
    }

    void Update()
    {
        TestData();
    }

    void OnDestroy()
    {
        socket.Close();
        Debug.Log("服务器端已关闭");
    }

    /// <summary>
    /// 初始化
    /// </summary>
    private void Socket_Init()
    {
        //3.创建Socket对象.
        //Socket socket = new Socket(地址类型，Socket 类型，协议类型);	
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //4.创建IP对象.
        //IPAddress address = IPAddress.Parse(ip 地址字符串);
        IPAddress address = IPAddress.Parse(ip);

        //5.创建端口对象.
        //IPEndPoint point = new IPEndPoint(ip 对象, 端口号);
        IPEndPoint point = new IPEndPoint(address, port);

        //6.监听绑定.
        //socket.Bind(端口对象);
        socket.Bind(point);

        //7.设置最大连接数.
        //socket.Listen(数字);
        socket.Listen(100);

        //实例化一个子线程对象.
        Thread acceptThred = new Thread(AcceptThread);
        //开启子线程.
        acceptThred.Start();
    }

    /// <summary>
    /// 测试用的
    /// </summary>
    private void TestData()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //SendMessage("Server:A");
            //SendMessage(GetClientSocket(0), "Server:A");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //SendMessage("Server:Monkey");
            //SendMessage(GetClientSocket(1), "Server:Monkey");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            //SendMessage("Server:各位网友大家下午好,我是Monkey!");
            SendAllMessage("serverlog|各位网友大家下午好,我是Monkey!!!!!");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("----------------------------");
            foreach (var item in clientDic.Keys)
            {
                Debug.Log(item.ToString());
            }
            Debug.Log("----------------------------");
        }
    }

    /// <summary>
    /// 子线程,负责监听用户的上线连接.
    /// </summary>
    private void AcceptThread()
    {
        while (true)
        {
            //8.监听客户端连接.
            Socket clientSocket = socket.Accept();

            if (clientDic.Count == 1)
            {
                foreach (var item in clientDic.Keys)
                {
                    //给第一个用户发消息.
                    SendMessage(GetClientSocket(item), "friendonline|" + clientSocket.RemoteEndPoint.ToString());
                    SendMessage(clientSocket, "friendonline|" + item);
                }
            }

            //把连接上线的客户端添加到字典结构中.
            clientDic.Add(clientSocket.RemoteEndPoint.ToString(), clientSocket);

            //9.输出客户端连接信息.
            Debug.Log(clientSocket.RemoteEndPoint.ToString() + ":已上线!");
            //开启子线程.
            Thread receiveThread = new Thread(ReceiveThread);
            //开启线程.
            receiveThread.Start(clientSocket);
        }
    }


    /// <summary>
    /// 子线程.循环接收用户发送过来的消息.
    /// </summary>
    private void ReceiveThread(object obj)
    {
        //参数类型强转.
        Socket clientSocket = (Socket)obj;
        //循环接收用户数据.
        while (true)
        {
            //定义一个字节类型的数组.
            byte[] message = new byte[1024];
            //接收数据.
            int length = clientSocket.Receive(message);
            //客户端下线.
            if (length == 0)
            {
                Debug.Log("客户端已下线!");
                break;
            }
            //转码成字符串.
            string str = Encoding.UTF8.GetString(message, 0, length);
            //对用户数据进行判断.
            if (str == "CLOSE")
            {
                RemoveClient(clientSocket.RemoteEndPoint.ToString());
            }
            else
            {


                //第二版消息处理.
                if (str.Contains("|"))
                {
                    string[] info = str.Split('|');
                    //Debug.Log("消息头:" + info[0]);
                    //Debug.Log("消息体:" + info[1]);
                    if (info[0] == "log")
                    {
                        Debug.Log(info[1]);
                    }
                    else if (info[0] == "friendinfo")
                    {
                        string[] body = info[1].Split('*');
                        //body[0]好友信息, body[1]消息正文.
                        SendMessage(GetClientSocket(body[0]), "serverlog|" + body[1]);
                    }

                }

            }
        }
    }

    /// <summary>
    /// 往特定客户端发送消息.
    /// </summary>
    private void SendMessage(Socket clientSocket, string text)
    {
        try
        {
            byte[] message = Encoding.UTF8.GetBytes(text);
            clientSocket.Send(message);
        }
        catch
        {
            Debug.Log("客户端已下线.");
        }
    }

    /// <summary>
    /// 给所有客户端发送消息.
    /// </summary>
    /// <param name="text"></param>
    private void SendAllMessage(string text)
    {
        foreach (var item in clientDic.Keys)
        {
            SendMessage(clientDic[item], text);
        }
    }

    /// <summary>
    /// 从字典结构中获取指定的子Socket对象.
    /// </summary>
    private Socket GetClientSocket(string str)
    {
        Socket tempSocket;
        clientDic.TryGetValue(str, out tempSocket);
        return tempSocket;
    }

    /// <summary>
    /// 从字典中移除指定的元素.
    /// </summary>
    private void RemoveClient(string str)
    {
        if (clientDic.Remove(str))
        {
            Debug.Log(str + "用户已下线");
        }

        if (clientDic.Count > 0)
        {
            foreach (var item in clientDic.Keys)
            {
                Debug.Log("服务端当前还存在用户"+item.ToString());
            }
        }
        else
        {
            Debug.Log("服务器端已经没有在线用户了.");
        }
    }



}
