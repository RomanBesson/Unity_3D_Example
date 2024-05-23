using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//1.引入相关命名空间.
using System.Net;
using System.Net.Sockets;
using System.Text;
using SocketDLL;

//默认委托.
public delegate void NormalDelegate();
//消息处理委托.
public delegate void MessageDelegate(MKClientState clientState, List<MKClientState> clientStateList, string str);

public class MKAsyncServer : MonoBehaviour {
    #region 字段
    public static MKAsyncServer Instance;    //单例.

    //2.字段.
    private string ip = DataConfig.IP_DATA;     //IP地址.
    private int port = 33333;                //端口号.
    private int maxCount = 100;              //最大连接数.
    private Socket socket;                   //主Socket对象.
    private List<MKClientState> clientStateList = new List<MKClientState>();    //客户端状态对象集合.

    public event NormalDelegate StartSocketEvent;   //Socket开启事件.
    public event NormalDelegate CloseSocketEvent;   //Socket关闭事件.
    public event MessageDelegate MessageEvent;      //消息处理事件.
    #endregion
    void Awake()
    {
       
        Instance = this;
    }

	void Start () {
        StartServer();
	}

    void OnDestroy () {
        CloseServer();
    }

    /// <summary>
    /// 开启服务器.
    /// </summary>
    private void StartServer()
    {
        //3.创建Socket对象.
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //4.创建IP对象.
        IPAddress address = IPAddress.Parse(ip);
        //5.创建端口对象.
        IPEndPoint point = new IPEndPoint(address, port);
        //6.监听绑定.
        socket.Bind(point);
        //7.设置最大连接数.
        socket.Listen(maxCount);

        //8.异步处理用户上线.
        socket.BeginAccept(new AsyncCallback(HandlerAccept), socket);

        StartSocketEvent();
    }

    /// <summary>
    /// 关闭服务器.
    /// </summary>
    private void CloseServer()
    {
        socket.Close();
        for (int i = 0; i < clientStateList.Count; i++)
        {
            clientStateList[i].ClientSocket.Close();
        }
        CloseSocketEvent();
        Message("服务器端已关闭");
    }

    /// <summary>
    /// 处理用户上线.
    /// </summary>
    private void HandlerAccept(IAsyncResult ar)
    {
        
        Socket tempSocket = (Socket)ar.AsyncState;      //服务器端主Socket.
        Socket clientSocket = socket.EndAccept(ar);     //客户端的子Socket.
        Message(clientSocket.RemoteEndPoint.ToString());

        //创建客户端状态对象.
        MKClientState clientState = new MKClientState(clientSocket);
        //状态对象添加入集合.
        clientStateList.Add(clientState);

        //初始化字节数组.
        clientState.ByteBuffer = new byte[socket.ReceiveBufferSize];
        //接收.
        clientSocket.BeginReceive(clientState.ByteBuffer, 0, clientState.ByteBuffer.Length, 0, new AsyncCallback(HandlerReceive), clientState);
        Message("用户上线.");
        //继续监听下一个用户的上线请求.
        socket.BeginAccept(new AsyncCallback(HandlerAccept), socket);
    }

    /// <summary>
    /// 接收到客户端发送过来的消息之后的回调方法.
    /// </summary>
    private void HandlerReceive(IAsyncResult ar)
    {
        Debug.Log("收到客户端发送的消息");
        //得到客户端状态对象.
        MKClientState clientState = (MKClientState)ar.AsyncState;
        //得到子Socket对象.
        Socket clientSocket = clientState.ClientSocket;
        //接收到的数据长度.
        int count = clientSocket.EndReceive(ar);
        if(count == 0)
        {
            Message("客户端已下线.");
            //移除对象.
            clientStateList.Remove(clientState);
            return;
        }

        //Debug.Log("Count:" + count);
        //Debug.Log("clientState.ByteBuffer:" + clientState.ByteBuffer.Length);


        //转码成字符串.
        string str = Encoding.UTF8.GetString(clientState.ByteBuffer, 0, count);
        Debug.Log("接收到客户端发送的消息" + str);
        //调用回复方法
        MessageEvent(clientState, clientStateList, str);

        #region 序列化测试代码
        //SocketMessage message = (SocketMessage)SocketTools.Deserialize(clientState.ByteBuffer, count);

        //switch (message.Head)
        //{
        //    case MessageHead.TestA:
        //        Person person = (Person)message.Body;
        //        Debug.Log("person.Name:" + person.Name);
        //        Debug.Log("person.Age:" + person.Age);
        //        break;
        //}
        #endregion

        //重置字节数组.
        clientState.ByteBuffer = new byte[socket.ReceiveBufferSize];
        //接收下一条数据.
        clientSocket.BeginReceive(clientState.ByteBuffer, 0, clientState.ByteBuffer.Length, 0, new AsyncCallback(HandlerReceive), clientState);
    }

    /// <summary>
    /// 消息发送方法.
    /// </summary>
    public void Send(Socket clientSocket, string text)
    {
        Debug.Log("服务器端正在发送：" + text);
        //将要发送的数据转码为UTF8格式的字节数组.
        byte[] message = Encoding.UTF8.GetBytes(text);
        //发送数据.
        clientSocket.BeginSend(message, 0, message.Length, 0, new AsyncCallback(HandlerSend), clientSocket);
    }

    /// <summary>
    /// 消息发送成功之后的回调方法.
    /// </summary>
    private void HandlerSend(IAsyncResult ar)
    {
        Socket clientSocket = (Socket)ar.AsyncState;
        //发送的数据量.
        int count = clientSocket.EndSend(ar);
        Message("消息发送成功");
    }


    /// <summary>
    /// 消息广播.
    /// </summary>
    public void SendAll()
    {
        for (int i = 0; i < clientStateList.Count; i++)
        {
            Send(clientStateList[i].ClientSocket, "服务器端发送过来的测试消息.");
        }
    }

 
    /// <summary>
    /// 消息调试.
    /// </summary>
    public void Message(string str)
    {
        Debug.Log("MESSAGE:" + str);
    }

}
