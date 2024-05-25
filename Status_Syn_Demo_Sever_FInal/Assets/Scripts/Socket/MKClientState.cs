using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using SocketDLL.Message;

/// <summary>
/// 子socket的实体类
/// </summary>
public class MKClientState {

    private byte[] byteBuffer; 
    private Socket clientSocket;
    private UserData userData;

    public byte[] ByteBuffer
    {
        get { return byteBuffer; }
        set { byteBuffer = value; }
    }

    public Socket ClientSocket
    {
        get { return clientSocket; }
        set { clientSocket = value; }
    }

    public UserData UserData
    {
        get { return userData; }
        set { userData = value; }
    }

    public MKClientState(Socket clientSocket)
    {
        this.clientSocket = clientSocket;
    }

}
