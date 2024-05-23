using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1.引入相关命名空间.
using System.Net;
using System.Net.Sockets;
using System.Text;

public class HandlerMessagePanel : MonoBehaviour {

    private MKAsyncServer serverSocket;
    private List<string> userInfoList = new List<string>();                 //模拟账号数据.


    void Start()
    {
        serverSocket = MKAsyncServer.Instance;

        serverSocket.StartSocketEvent += InitUserInfo;
        serverSocket.CloseSocketEvent += RemoveUserInfo;
        serverSocket.MessageEvent += HandlerMessage;

    }


    /// <summary>
    /// 初始化用户数据.
    /// </summary>
    private void InitUserInfo()
    {
        userInfoList.Add("monkey");
        userInfoList.Add("mkcode");
        userInfoList.Add("lkk");
    }

    /// <summary>
    /// 清空模拟账号数据.
    /// </summary>
    private void RemoveUserInfo()
    {
        userInfoList.Clear();
        userInfoList = null;
    }

    /// <summary>
    /// 获取用户数据字符串.
    /// </summary>
    /// <returns></returns>
    private string GetUserInfo()
    {
        string tempStr = null;
        for (int i = 0; i < userInfoList.Count; i++)
        {
            tempStr += userInfoList[i];
            if (i != userInfoList.Count - 1)
            {
                tempStr += "*";
            }
        }
        return tempStr;
    }


    /// <summary>
    /// 聊天模块消息处理.
    /// </summary>
    private void HandlerMessage(MKClientState clientState, List<MKClientState> clientStateList, string str)
    {
        //得到子Socket对象.
        Socket clientSocket = clientState.ClientSocket;

        //处理获取好友数据.
        if (str == "GetOnLine")
        {
            Debug.Log("正在获取好友数据");
            string tempStr = null;
            for (int i = 0; i < clientStateList.Count; i++)
            {
                if (clientStateList[i].UserInfo != "")
                {
                    tempStr += clientStateList[i].UserInfo;
                    if (i != userInfoList.Count - 1)
                    {
                        tempStr += "*";
                    }
                }
            }
            Debug.Log("获取成功");
            serverSocket.Send(clientSocket, "GetOnLine|" + tempStr);

            //新上线用户.
            if (clientStateList.Count > 1)
            {
                Debug.Log("有新用户上线");
                for (int i = 0; i < clientStateList.Count; i++)
                {
                    if (clientStateList[i] != clientState)
                    {
                        serverSocket.Send(clientStateList[i].ClientSocket, "NewOnLine|" + clientState.UserInfo);
                    }
                }
            }
        }
        if (str.Contains("|"))
        {
            string[] info = str.Split('|');
            if (info[0] == "Login")
            {
                Debug.Log("正在验证登录信息");
                if (userInfoList.Contains(info[1]))
                {
                    clientState.UserInfo = info[1];
                    serverSocket.Send(clientSocket, "LoginOK|" + GetUserInfo());
                    serverSocket.Message(info[1] + ":账号登录成功.");
                }
                else
                {
                    serverSocket.Message(info[1] + ":账号不存在.");
                }
            }
            else if (info[0] == "Exit")
            {
                Debug.Log("当前客户端正在退出");
                clientStateList.Remove(clientState);
                clientState.ClientSocket.Close();
            }
            else if (info[0] == "GroupMessage")
            {
                Debug.Log("正在处理发送的消息");
                for (int i = 0; i < clientStateList.Count; i++)
                {
                    serverSocket.Send(clientStateList[i].ClientSocket, "GroupMessage|" + clientState.UserInfo + ":" + info[1]);
                }
            }
        }
    }


}
