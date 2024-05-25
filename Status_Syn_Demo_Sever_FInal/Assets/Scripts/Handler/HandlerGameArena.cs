using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using SocketDLL;
using SocketDLL.Message;

/// <summary>
/// 负责竞技场消息的处理
/// </summary>
public class HandlerGameArena : MonoBehaviour {

    private MKAsyncServer serverSocket;
    private UserManager userManager;

    void Start()
    {
        serverSocket = MKAsyncServer.Instance;
        userManager = UserManager.Instance;
        serverSocket.MessageEvent += HandlerArenaMessage;
    }

    /// <summary>
    /// 处理竞技场消息.
    /// </summary>
    private void HandlerArenaMessage(MKClientState clientState, SocketMessage message)
    {
        Socket clientSocket = clientState.ClientSocket;

        switch (message.Head)
        {
            case MessageHead.CS_EnterArena:
                int id = (int)message.Body;
                MKClientState state = userManager.GetMKClientStateByID(id);
                if (userManager.AddWaitPlayer(state))
                {
                    //开启竞技场相关代码逻辑.
                    int[] ids = userManager.InitArena();

                    //非竞技场角色客户端.
                    for (int i = 0; i < userManager.CityPlayerList.Count; i++)
                    {
                        PlayersExit(userManager.CityPlayerList[i].ClientSocket, ids);
                    }

                    //竞技场角色客户端.
                    EnterArena(userManager.Arena.PlayerA.ClientSocket);
                    EnterArena(userManager.Arena.PlayerB.ClientSocket);
                }
                break;
            case MessageHead.CS_NewPlayerEnterArena:
                CreateArenaPlayer(clientSocket, userManager.GetArenaList());
                break;
            case MessageHead.CS_ArenaPlayerMove:
                Move move = (Move)message.Body;
                ArenaPlayerMove(userManager.Arena.PlayerA.ClientSocket, move);
                ArenaPlayerMove(userManager.Arena.PlayerB.ClientSocket, move);
                break;
            case MessageHead.CS_ArenaPlayerAttack:
                int attackID = (int)message.Body;
                ArenaPlayerAttack(userManager.Arena.PlayerA.ClientSocket, attackID);
                ArenaPlayerAttack(userManager.Arena.PlayerB.ClientSocket, attackID);
                break;
            case MessageHead.CS_Hit:
                int hitID = (int)message.Body;
                HitInfo info = userManager.CalcHit(hitID);
                ArenaHit(userManager.Arena.PlayerA.ClientSocket, info);
                ArenaHit(userManager.Arena.PlayerB.ClientSocket, info);
                break;
        }

    }


    /// <summary>
    /// 竞技场伤害计算.
    /// </summary>
    private void ArenaHit(Socket clientSocket, HitInfo info)
    {
        //消息体封装.
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.SC_Hit;
        message.Body = info;

        //序列化.
        byte[] bytes = SocketTools.Serialize(message);

        //发送.
        serverSocket.Send(clientSocket, bytes);
    }

    /// <summary>
    /// 竞技场角色攻击.
    /// </summary>
    private void ArenaPlayerAttack(Socket clientSocket, int id)
    {
        //消息体封装.
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.SC_ArenaPlayerAttack;
        message.Body = id;

        //序列化.
        byte[] bytes = SocketTools.Serialize(message);

        //发送.
        serverSocket.Send(clientSocket, bytes);
    }


    /// <summary>
    /// 竞技场角色移动.
    /// </summary>
    private void ArenaPlayerMove(Socket clientSocket, Move move)
    {
        //消息体封装.
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.SC_ArenaPlayerMove;
        message.Body = move;

        //序列化.
        byte[] bytes = SocketTools.Serialize(message);

        //发送.
        serverSocket.Send(clientSocket, bytes);
    }



    /// <summary>
    /// 多个角色进入主城消息.
    /// </summary>
    private void PlayersExit(Socket clientSocket, int[] ids)
    {
        //消息体封装.
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.SC_ExitCity;
        message.Body = ids;

        //序列化.
        byte[] bytes = SocketTools.Serialize(message);

        //发送.
        serverSocket.Send(clientSocket, bytes);
    }


    /// <summary>
    /// 角色进入竞技场消息.
    /// </summary>
    private void EnterArena(Socket clientSocket)
    {
        //消息体封装.
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.SC_EnterArena;
        message.Body = null;

        //序列化.
        byte[] bytes = SocketTools.Serialize(message);

        //发送.
        serverSocket.Send(clientSocket, bytes);
    }


    /// <summary>
    /// 服务器端返回竞技场角色数据集合.
    /// </summary>
    private void CreateArenaPlayer(Socket clientSocket, List<UserData> userDataList)
    {
        //消息体封装.
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.SC_NewPlayerEnterArena;
        message.Body = userDataList;

        //序列化.
        byte[] bytes = SocketTools.Serialize(message);

        //发送.
        serverSocket.Send(clientSocket, bytes);
    }


}
