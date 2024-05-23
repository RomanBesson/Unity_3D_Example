using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class MKClientState {

    private byte[] byteBuffer; 
    private Socket clientSocket;
    private string userInfo;

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

    public string UserInfo
    {
        get { return userInfo; }
        set { userInfo = value; }
    }

    public MKClientState(Socket clientSocket)
    {
        this.clientSocket = clientSocket;
    }

}
