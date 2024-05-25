using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketDLL;
using SocketDLL.Message;

public class GameCityView : MonoBehaviour {

    private Transform m_Transform;
    private Button arenaButton;
    private MKAsyncClient clientSocket;

    private GameObject prefab_UserInfo;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        arenaButton = m_Transform.Find("ArenaButton").GetComponent<Button>();
        clientSocket = MKAsyncClient.Instance;

        arenaButton.onClick.AddListener(EnterArena);

        InitUserInfoUI();
        SaveCurrentUserInfo();
        NewPlayerEnterCity();
	}

    /// <summary>
    /// 初始化角色信息区UI界面.
    /// </summary>
    private void InitUserInfoUI()
    {
        prefab_UserInfo = Resources.Load<GameObject>("UserInfo");
        UserInfoView userInfoView = GameObject.Instantiate<GameObject>(prefab_UserInfo, m_Transform).GetComponent<UserInfoView>();
        userInfoView.DataInit(clientSocket.CurrentPlayerData);
    }

    /// <summary>
    /// 存储当前角色信息.
    /// </summary>
    private void SaveCurrentUserInfo()
    {
        CityPlayerManager.Instance.CurrentID = clientSocket.CurrentPlayerData.ID;
        CityPlayerManager.Instance.Add(clientSocket.CurrentPlayerData.ID, new CityPlayer(clientSocket.CurrentPlayerData));
    }

    /// <summary>
    /// 新角色进入主城请求.
    /// </summary>
    private void NewPlayerEnterCity()
    {
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.CS_PlayerEnterCity;
        message.Body = clientSocket.CurrentPlayerData.ID;

        byte[] bytes = SocketTools.Serialize(message);

        clientSocket.Send(bytes);
    }

    /// <summary>
    /// 进入竞技场.
    /// </summary>
    private void EnterArena()
    {
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.CS_EnterArena;
        message.Body = clientSocket.CurrentPlayerData.ID;

        byte[] bytes = SocketTools.Serialize(message);

        clientSocket.Send(bytes);
    }
}
