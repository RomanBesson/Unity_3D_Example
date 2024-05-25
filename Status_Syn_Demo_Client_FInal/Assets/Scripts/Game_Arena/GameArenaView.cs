using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketDLL;
using SocketDLL.Message;

public class GameArenaView : MonoBehaviour {

    private Transform m_Transform;
    private MKAsyncClient clientSocket;

    private GameObject prefab_UserInfo;
    private UserInfoView userInfoView;

    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        clientSocket = MKAsyncClient.Instance;

        InitUserInfoUI();
        SaveCurrentUserInfo();
        NewPlayerEnterArena();
    }

    /// <summary>
    /// 初始化角色信息区UI界面.
    /// </summary>
    private void InitUserInfoUI()
    {
        prefab_UserInfo = Resources.Load<GameObject>("UserInfo");
        userInfoView = GameObject.Instantiate<GameObject>(prefab_UserInfo, m_Transform).GetComponent<UserInfoView>();
        userInfoView.DataInit(clientSocket.CurrentPlayerData);
    }

    /// <summary>
    /// 存储当前角色信息.
    /// </summary>
    private void SaveCurrentUserInfo()
    {

        ArenaPlayerManager.Instance.CurrentID = clientSocket.CurrentPlayerData.ID;
        ArenaPlayerManager.Instance.Add(clientSocket.CurrentPlayerData.ID, new CityPlayer(clientSocket.CurrentPlayerData, userInfoView));
    }

    /// <summary>
    /// 新角色进入竞技场请求.
    /// </summary>
    private void NewPlayerEnterArena()
    {
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.CS_NewPlayerEnterArena;
        message.Body = clientSocket.CurrentPlayerData.ID;

        byte[] bytes = SocketTools.Serialize(message);

        clientSocket.Send(bytes);
    }

}
