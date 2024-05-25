using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketDLL;
using SocketDLL.Message;

public class HandlerGameArena : MonoBehaviour {

    private MKAsyncClient clientSocket = null;
    private HandlerThread mainThread = null;

    private List<UserData> userDataList = null;
    private Move move = null;
    private int attackID = 0;
    private HitInfo info = null;

    void Start()
    {
        clientSocket = MKAsyncClient.Instance;
        mainThread = HandlerThread.Instance;
        clientSocket.MessageEvent += HandlerArenaMessage;
    }

    /// <summary>
    /// 竞技场消息处理.
    /// </summary>
    private void HandlerArenaMessage(SocketMessage message)
    { 
        switch(message.Head)
        {
            case MessageHead.SC_NewPlayerEnterArena:
                userDataList = (List<UserData>)message.Body;
                mainThread.AddDelegate(CreateArenaPlayers);
                break;
            case MessageHead.SC_ArenaPlayerMove:
                move = (Move)message.Body;
                mainThread.AddDelegate(PlayerMove);
                break;
            case MessageHead.SC_ArenaPlayerAttack:
                attackID = (int)message.Body;
                mainThread.AddDelegate(PlayerAttack);
                break;
            case MessageHead.SC_Hit:
                info = (HitInfo)message.Body;
                mainThread.AddDelegate(PlayerHit);
                break;
        }
    }


    /// <summary>
    /// 角色受伤害.
    /// </summary>
    private void PlayerHit()
    {
        CityPlayer cityPlayer = ArenaPlayerManager.Instance.GetCityPlayerByID(info.ID);
        cityPlayer.Player.GetComponent<PlayerController>().Hit();
        cityPlayer.UserInfoView.SetBloodInfo(info.HP, info.Blood);
    }

    /// <summary>
    /// 竞技场角色移动.
    /// </summary>
    private void PlayerMove()
    {
        CityPlayer cityPlayer = ArenaPlayerManager.Instance.GetCityPlayerByID(move.ID);
        PlayerController playerController = cityPlayer.Player.GetComponent<PlayerController>();
        playerController.Move(move.X, move.Y, move.Z);
        move = null;
    }


    /// <summary>
    /// 竞技场角色攻击.
    /// </summary>
    private void PlayerAttack()
    {
        CityPlayer cityPlayer = ArenaPlayerManager.Instance.GetCityPlayerByID(attackID);
        PlayerController playerController = cityPlayer.Player.GetComponent<PlayerController>();
        playerController.Attack();
        move = null;
    }


    /// <summary>
    /// 创建竞技场角色.
    /// </summary>
    private void CreateArenaPlayers()
    {
        for (int i = 0; i < userDataList.Count; i++)
        {  
            //实例化生成本地角色.
            if (userDataList[i].ID == ArenaPlayerManager.Instance.CurrentID)
            {
                CreatePlayer(userDataList[i]);
                continue;
            }

            //实例化生成其他角色.
            GameObject prefab = Resources.Load<GameObject>(userDataList[i].ModelInfo.ModelName);
            Vector3 pos = new Vector3(
                    userDataList[i].PositionInfo.Pos_X,
                    userDataList[i].PositionInfo.Pos_Y,
                    userDataList[i].PositionInfo.Pos_Z
                );
            Vector3 rot = new Vector3(
                    userDataList[i].PositionInfo.Rot_X,
                    userDataList[i].PositionInfo.Rot_Y,
                    userDataList[i].PositionInfo.Rot_Z
                );
            Color color = new Color(
                    userDataList[i].ModelInfo.R,
                    userDataList[i].ModelInfo.G,
                    userDataList[i].ModelInfo.B
                );

            GameObject player = GameObject.Instantiate<GameObject>(prefab, pos, Quaternion.Euler(rot));
            GameObject ui = CreateFollowUI(player);
            UserInfoView view = InitUserInfoUI(userDataList[i]);
            player.GetComponent<PlayerController>().FollowUI = ui;
            ui.GetComponent<UIFollowPlayer>().SetText(userDataList[i].UserName);
            player.GetComponent<Transform>().SetParent(ArenaPlayerManager.Instance.M_Transform);
            //player.GetComponent<MeshRenderer>().material.color = color;

            CityPlayer cityPlayer = new CityPlayer(userDataList[i], player, view);
            ArenaPlayerManager.Instance.Add(userDataList[i].ID, cityPlayer);
        }
        userDataList.Clear();
        userDataList = null;
    }

    /// <summary>
    /// 角色实例化.
    /// </summary>
    private void CreatePlayer(UserData userData)
    {
        CityPlayer cityPlayer = ArenaPlayerManager.Instance.GetCityPlayerByID(ArenaPlayerManager.Instance.CurrentID);
        GameObject prefab = Resources.Load<GameObject>(cityPlayer.UserData.ModelInfo.ModelName);
        Vector3 pos = new Vector3(
                userData.PositionInfo.Pos_X,
                userData.PositionInfo.Pos_Y,
                userData.PositionInfo.Pos_Z
            );
        Vector3 rot = new Vector3(
                cityPlayer.UserData.PositionInfo.Rot_X,
                cityPlayer.UserData.PositionInfo.Rot_Y,
                cityPlayer.UserData.PositionInfo.Rot_Z
            );
        Color color = new Color(
                cityPlayer.UserData.ModelInfo.R,
                cityPlayer.UserData.ModelInfo.G,
                cityPlayer.UserData.ModelInfo.B
            );

        GameObject player = GameObject.Instantiate<GameObject>(prefab, pos, Quaternion.Euler(rot));
        GameObject ui = CreateFollowUI(player);
        player.GetComponent<PlayerController>().FollowUI = ui;
        ui.GetComponent<UIFollowPlayer>().SetText(cityPlayer.UserData.UserName);
        player.GetComponent<Transform>().SetParent(ArenaPlayerManager.Instance.M_Transform);
        //player.GetComponent<MeshRenderer>().material.color = color;
        cityPlayer.Player = player;
    }

    /// <summary>
    /// 实例化生成角色跟随UI.
    /// </summary>
    private GameObject CreateFollowUI(GameObject player)
    {
        GameObject prefab = Resources.Load<GameObject>("UIFollowPlayer");
        GameObject ui = GameObject.Instantiate<GameObject>(prefab, GameObject.Find("Canvas").GetComponent<Transform>());
        ui.GetComponent<UIFollowPlayer>().PlayerTransform = player.GetComponent<Transform>();
        return ui;
    }

    /// <summary>
    /// 初始化角色信息区UI界面.
    /// </summary>
    private UserInfoView InitUserInfoUI(UserData userData)
    {
        GameObject prefab_UserInfo = Resources.Load<GameObject>("UserInfo");
        Transform parent = GameObject.Find("Canvas").GetComponent<Transform>();
        GameObject ui = GameObject.Instantiate<GameObject>(prefab_UserInfo, parent);
        UserInfoView userInfoView = ui.GetComponent<UserInfoView>();

        ui.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        ui.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
        ui.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-270, 0, 0);

        userInfoView.DataInit(userData);
        return userInfoView;
    }

}
