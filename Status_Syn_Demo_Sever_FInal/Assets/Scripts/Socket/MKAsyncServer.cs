using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//1.引入相关命名空间.
using System.Net;
using System.Net.Sockets;
using System.Text;
using SocketDLL;
using SocketDLL.Message;

//默认委托.
public delegate void NormalDelegate();
//消息处理委托.
public delegate void MessageDelegate(MKClientState clientState, SocketMessage message);

/// <summary>
/// 处理Socket连接，发送消息
/// </summary>
public class MKAsyncServer : MonoBehaviour {

    public static MKAsyncServer Instance;    //单例.
    private UserManager userManager;

    //2.字段.
    private string ip = "";      //IP地址.
    private int port = 33333;                //端口号.
    private int maxCount = 100;              //最大连接数.
    private Socket socket;                   //主Socket对象.
    
    public event NormalDelegate StartSocketEvent;   //Socket开启事件.
    public event NormalDelegate CloseSocketEvent;   //Socket关闭事件.
    public event MessageDelegate MessageEvent;      //消息处理事件.

    void Awake()
    {
        Instance = this;
    }

	void Start () {
        StartServer();
        userManager = UserManager.Instance;
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

        //StartSocketEvent();
        Message("服务器端已启动.");
    }

    /// <summary>
    /// 关闭服务器.
    /// </summary>
    private void CloseServer()
    {
        socket.Close();
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
        Message("用户：" + clientSocket.RemoteEndPoint.ToString() + "已上线");

        //创建客户端状态对象.
        MKClientState clientState = new MKClientState(clientSocket);
        //状态对象添加入集合.
        userManager.Add(clientState);

        //初始化字节数组.
        clientState.ByteBuffer = new byte[socket.ReceiveBufferSize];
        //接收.
        clientSocket.BeginReceive(clientState.ByteBuffer, 0, clientState.ByteBuffer.Length, 0, new AsyncCallback(HandlerReceive), clientState);

        //继续监听下一个用户的上线请求.
        socket.BeginAccept(new AsyncCallback(HandlerAccept), socket);
    }

    /// <summary>
    /// 接收到客户端发送过来的消息之后的回调方法.
    /// </summary>
    private void HandlerReceive(IAsyncResult ar)
    {
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
            userManager.Remove(clientState);
            return;
        }
        SocketMessage message = (SocketMessage)SocketTools.Deserialize(clientState.ByteBuffer, count);
        Debug.Log("收到客户端的消息" + message.ToString());
        MessageEvent(clientState, message);

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
        //将要发送的数据转码为UTF8格式的字节数组.
        byte[] message = Encoding.UTF8.GetBytes(text);
        //发送数据.
        clientSocket.BeginSend(message, 0, message.Length, 0, new AsyncCallback(HandlerSend), clientSocket);
    }

    /// <summary>
    /// 消息发送方法.
    /// </summary>
    public void Send(Socket clientSocket, byte[] bytes)
    {
        //发送数据.
        clientSocket.BeginSend(bytes, 0, bytes.Length, 0, new AsyncCallback(HandlerSend), clientSocket);
    }


    /// <summary>
    /// 消息发送成功之后的回调方法.
    /// </summary>
    private void HandlerSend(IAsyncResult ar)
    {
        Debug.Log("正在向客户端发送消息");
        Socket clientSocket = (Socket)ar.AsyncState;
        //发送的数据量.
        int count = clientSocket.EndSend(ar);
        Message("消息发送成功,长度为:" + count);
    }


    /// <summary>
    /// 消息广播.
    /// </summary>
    public void SendAll()
    {
        for (int i = 0; i < userManager.ClientStateList.Count; i++)
        {
            Send(userManager.ClientStateList[i].ClientSocket, "服务器端发送过来的测试消息.");
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
