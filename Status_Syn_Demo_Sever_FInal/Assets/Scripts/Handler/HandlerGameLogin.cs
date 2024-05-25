using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using SocketDLL;
using SocketDLL.Message;

public class HandlerGameLogin : MonoBehaviour {

    private MKAsyncServer serverSocket;
    private UserManager userManager;

	void Start () {
        serverSocket = MKAsyncServer.Instance;
        userManager = UserManager.Instance;
        serverSocket.MessageEvent += HandlerLoginMessage;
	}
	
    /// <summary>
    /// 处理登录消息.
    /// </summary>
    private void HandlerLoginMessage(MKClientState clientState, SocketMessage message)
    {
        Socket clientSocket = clientState.ClientSocket;

        switch (message.Head)
        {
            case MessageHead.CS_Login:
                Login login = (Login)message.Body;
                UserData userData = userManager.GetUserData(login.UserName);
                if(userData != null)
                {
                    //匹配正确,登录成功.
                    HandlerLogin(clientSocket, userData);
                    clientState.UserData = userData;
                }
                else
                {
                    //匹配错误,登录失败.
                    HandlerLogin(clientSocket, null);
                }
                break;


        }
    }


    /// <summary>
    /// 处理账号登录.
    /// </summary>
    private void HandlerLogin(Socket clientSocket, UserData userData)
    {
        //消息体封装.
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.SC_Login;
        message.Body = userData;

        //序列化.
        byte[] bytes = SocketTools.Serialize(message);

        //发送.
        serverSocket.Send(clientSocket, bytes);
    }
}
