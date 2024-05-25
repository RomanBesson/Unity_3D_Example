using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using SocketDLL;
using SocketDLL.Message;

public class HandlerGameCity : MonoBehaviour {

    private MKAsyncServer serverSocket;
    private UserManager userManager;

    void Start()
    {
        serverSocket = MKAsyncServer.Instance;
        userManager = UserManager.Instance;
        serverSocket.MessageEvent += HandlerEnterCityMessage;
    }

    /// <summary>
    /// 处理新角色进入主城消息.
    /// </summary>
    private void HandlerEnterCityMessage(MKClientState clientState, SocketMessage message)
    {
        Socket clientSocket = clientState.ClientSocket;

        switch (message.Head)
        {
            case MessageHead.CS_PlayerEnterCity:
                int id = (int)message.Body;
                if (userManager.Move(id))
                {
                    //<1>A玩家是第一个进入主城的角色.
                    if (userManager.CityPlayerList.Count == 1)
                    {
                        HandlerEnterCity(clientSocket, "OK");
                    }
 
                    if(userManager.CityPlayerList.Count > 1)
                    {
                        //<2>A玩家是第N个进入主城的角色.
                        HandlerCreateAll(clientSocket, userManager.GetCityUserDataList());

                        //<3>通知其他客户端A玩家进入主城.
                        UserData currentUserData = userManager.GetUserDataByID(id);
                        for (int i = 0; i < userManager.CityPlayerList.Count; i++)
                        {
                            if(userManager.CityPlayerList[i].UserData.ID != id)
                            {
                                HandlerCreateOne(userManager.CityPlayerList[i].ClientSocket, currentUserData);
                            }
                        }
                    }
                    
                }
                else
                {
                    //服务器端逻辑错误.
                    HandlerEnterCity(clientSocket, "服务器端逻辑错误");
                }
                break;

            case MessageHead.CS_PlayerMove:
                Move move = (Move)message.Body;
                UserData userData = UserManager.Instance.GetUserDataByID(move.ID);
                userData.PositionInfo.Pos_X = move.X;
                userData.PositionInfo.Pos_Y = move.Y;
                userData.PositionInfo.Pos_Z = move.Z;

                for (int i = 0; i < userManager.CityPlayerList.Count; i++)
                {
                    PlayerMove(userManager.CityPlayerList[i].ClientSocket, move);
                }
                break;
            case MessageHead.CS_Exit:
                int exitID = (int)message.Body;
                userManager.RemovePlayerByID(exitID);
                for (int i = 0; i < userManager.CityPlayerList.Count; i++)
                {
                    PlayerExit(userManager.CityPlayerList[i].ClientSocket, exitID);
                }
                break;

        }
    }

    /// <summary>
    /// 处理角色进入主城.
    /// </summary>
    private void HandlerEnterCity(Socket clientSocket, string str)
    {
        //消息体封装.
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.SC_CreateNewPlayer;
        message.Body = str;

        //序列化.
        byte[] bytes = SocketTools.Serialize(message);

        //发送.
        serverSocket.Send(clientSocket, bytes);
    }

    /// <summary>
    /// 创建主城内所有玩家角色.
    /// </summary>
    private void HandlerCreateAll(Socket clientSocket, List<UserData> userDataList)
    {
        //消息体封装.
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.SC_CreateAllPlayer;
        message.Body = userDataList;

        //序列化.
        byte[] bytes = SocketTools.Serialize(message);

        //发送.
        serverSocket.Send(clientSocket, bytes);
    }


    /// <summary>
    /// 实例化新角色.
    /// </summary>
    private void HandlerCreateOne(Socket clientSocket, UserData userData)
    {
        //消息体封装.
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.SC_CreateNewPlayer;
        message.Body = userData;

        //序列化.
        byte[] bytes = SocketTools.Serialize(message);

        //发送.
        serverSocket.Send(clientSocket, bytes);
    }

    /// <summary>
    /// 角色模型移动消息.
    /// </summary>
    private void PlayerMove(Socket clientSocket, Move move)
    {
        //消息体封装.
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.SC_PlayerMove;
        message.Body = move;

        //序列化.
        byte[] bytes = SocketTools.Serialize(message);

        //发送.
        serverSocket.Send(clientSocket, bytes);
    }

    /// <summary>
    /// x角色退出消息.
    /// </summary>
    private void PlayerExit(Socket clientSocket, int exitID)
    {
        //消息体封装.
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.SC_Exit;
        message.Body = exitID;

        //序列化.
        byte[] bytes = SocketTools.Serialize(message);

        //发送.
        serverSocket.Send(clientSocket, bytes);
    }

}
