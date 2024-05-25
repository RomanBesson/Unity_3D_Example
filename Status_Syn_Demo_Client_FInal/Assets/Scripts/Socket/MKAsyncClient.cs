using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1.引入相关命名空间.
using System.Net;
using System.Net.Sockets;
using System;
using System.Text;
using SocketDLL;
using SocketDLL.Message;

//默认委托.
public delegate void NormalDelegate();
//消息处理委托.
public delegate void MessageDelegate(SocketMessage message);

public class MKAsyncClient : MonoBehaviour {

    public static MKAsyncClient Instance;    //单例.

    //2.字段.
    private string ip = "";      //IP地址.
    private int port = 33333;                //端口号.
    private Socket socket;                   //主Socket对象.
    private IPEndPoint point;                //端口对象.

    private byte[] byteBuffer;               //字节缓冲区.
    private bool socketState = false;        //Socket状态.

    public event MessageDelegate MessageEvent;    //消息处理事件.

    [SerializeField]
    private UserData currentPlayerData;       //当前角色的数据.
    public UserData CurrentPlayerData
    {
        get { return currentPlayerData; }
        set { currentPlayerData = value; }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        StartClient();
    }
	
    void OnDestroy () {
        CloseClient();
    }

    /// <summary>
    /// 开启客户端.
    /// </summary>
    public void StartClient()
    {
        //3.创建Socket对象.
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //4.创建IP对象.
        IPAddress address = IPAddress.Parse(ip);
        //5.创建端口对象.
        point = new IPEndPoint(address, port);

        //6.异步方法连接服务器端.
        socket.BeginConnect(point, new AsyncCallback(HandlerConnect), socket);

        //初始化字节数组.
        byteBuffer = new byte[socket.ReceiveBufferSize];
        //接收.
        socket.BeginReceive(byteBuffer, 0, byteBuffer.Length, 0, new AsyncCallback(HandlerReceive), socket);
    }

    /// <summary>
    /// 关闭客户端.
    /// </summary>
    private void CloseClient()
    {
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.CS_Exit;
        message.Body = CityPlayerManager.Instance.CurrentID;
        byte[] bytes = SocketTools.Serialize(message);
        Send(bytes);

        if (socketState) socket.Close();
        socketState = false;       
        Message("客户端已经下线.");
    }

    /// <summary>
    /// 处理客户端连接服务器端.
    /// </summary>
    private void HandlerConnect(IAsyncResult ar)
    {
        if(socket.Connected)
        {
            Message("客户端连接服务器端成功.");
            socketState = true;
            Socket tempSocket = (Socket)ar.AsyncState;
            socket.EndConnect(ar);
        }
        else
        {
            Message("客户端连接服务器端失败.");
        }

    }

    /// <summary>
    /// 消息发送方法.
    /// </summary>
    public void Send(string text)
    {
        if (socketState == false) return;
        //将要发送的数据转码为UTF8格式的字节数组.
        byte[] message = Encoding.UTF8.GetBytes(text);
        try
        {
            //发送数据.
            socket.BeginSend(message, 0, message.Length, 0, new AsyncCallback(HandlerSend), socket);
        }
        catch
        {
            Message("消息发送失败.");
        }
    }


    /// <summary>
    /// 消息发送方法.
    /// </summary>
    public void Send(byte[] bytes)
    {
        if (socketState == false) return;
        try
        {
            //发送数据.
            socket.BeginSend(bytes, 0, bytes.Length, 0, new AsyncCallback(HandlerSend), socket);
        }
        catch
        {
            Message("消息发送失败.");
        }
    }

    /// <summary>
    /// 消息发送成功之后的回调方法.
    /// </summary>
    private void HandlerSend(IAsyncResult ar)
    {
        //发送的数据量.
        int count = socket.EndSend(ar);
        Message("消息发送成功,长度为:" + count);
    }


    /// <summary>
    /// 接收到服务器端发送过来的消息之后的回调方法.
    /// </summary>
    private void HandlerReceive(IAsyncResult ar)
    {
        //接收到的数据长度.
        int count = socket.EndReceive(ar);
        if (count == 0)
        {
            Message("长度为0.");
            return;
        }
        SocketMessage message = (SocketMessage)SocketTools.Deserialize(byteBuffer, count);
        MessageEvent(message);

        //重置字节数组.
        byteBuffer = new byte[socket.ReceiveBufferSize];
        //接收下一条数据.
        socket.BeginReceive(byteBuffer, 0, byteBuffer.Length, 0, new AsyncCallback(HandlerReceive), socket);
    }

    /// <summary>
    /// 重连服务器端.
    /// </summary>
    public void ResetConnect()
    {
        socket.BeginConnect(point, new AsyncCallback(HandlerConnect), socket);
    }

    /// <summary>
    /// 消息调试.
    /// </summary>
    private void Message(string str)
    {
        Debug.Log("MESSAGE:" + str);
    }

}
