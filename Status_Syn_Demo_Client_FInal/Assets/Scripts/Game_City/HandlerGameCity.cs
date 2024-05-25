using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SocketDLL;
using SocketDLL.Message;

public class HandlerGameCity : MonoBehaviour {
    
    private MKAsyncClient clientSocket = null;
    private HandlerThread mainThread = null;

    private List<UserData> userDataList = null;
    private UserData userData = null;
    private Move move = null;
    private int exitID = 0;
    private int[] ids = null;

    void Start()
    {
        clientSocket = MKAsyncClient.Instance;
        mainThread = HandlerThread.Instance;
        clientSocket.MessageEvent += HandlerCityMessage;
    }

    /// <summary>
    /// 主城消息处理.
    /// </summary>
    private void HandlerCityMessage(SocketMessage message)
    {
        switch(message.Head)
        {
            case MessageHead.SC_CreateNewPlayer:
                if(message.Body.ToString() == "OK")
                {
                    mainThread.AddDelegate(CreatePlayer);
                }
                else
                {
                    userData = (UserData)message.Body;
                    mainThread.AddDelegate(CreateNewPlayer);
                }
                break;
            case MessageHead.SC_CreateAllPlayer:
                userDataList = (List<UserData>)message.Body;
                mainThread.AddDelegate(CreateAllPlayer);
                break;
            case MessageHead.SC_PlayerMove:
                move = (Move)message.Body;
                mainThread.AddDelegate(PlayerMove);
                break;
            case MessageHead.SC_Exit:
                exitID = (int)message.Body;
                mainThread.AddDelegate(PlayerExit);
                break;
            case MessageHead.SC_ExitCity:
                ids = (int[])message.Body;
                mainThread.AddDelegate(PlayersExit);
                break;
            case MessageHead.SC_EnterArena:
                mainThread.AddDelegate(EnterArena);
                break;
        }

    }

    /// <summary>
    /// 角色实例化.
    /// </summary>
    private void CreatePlayer()
    {
        CityPlayer cityPlayer = CityPlayerManager.Instance.GetCityPlayerByID(CityPlayerManager.Instance.CurrentID);
        GameObject prefab = Resources.Load<GameObject>(cityPlayer.UserData.ModelInfo.ModelName);
        Vector3 pos = new Vector3(
                cityPlayer.UserData.PositionInfo.Pos_X,
                cityPlayer.UserData.PositionInfo.Pos_Y,
                cityPlayer.UserData.PositionInfo.Pos_Z
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
        player.GetComponent<Transform>().SetParent(CityPlayerManager.Instance.M_Transform);
        //player.GetComponent<MeshRenderer>().material.color = color;
        cityPlayer.Player = player;
    }


    /// <summary>
    /// 实例化所有角色.
    /// </summary>
    private void CreateAllPlayer()
    {
        for (int i = 0; i < userDataList.Count; i++)
        {
            //实例化生成本地角色.
            if (userDataList[i].ID == CityPlayerManager.Instance.CurrentID)
            {
                CreatePlayer();
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
            player.GetComponent<PlayerController>().FollowUI = ui;
            ui.GetComponent<UIFollowPlayer>().SetText(userDataList[i].UserName);
            player.GetComponent<Transform>().SetParent(CityPlayerManager.Instance.M_Transform);
            //player.GetComponent<MeshRenderer>().material.color = color;

            CityPlayer cityPlayer = new CityPlayer(userDataList[i], player);
            CityPlayerManager.Instance.Add(userDataList[i].ID, cityPlayer);
        }
        userDataList.Clear();
        userDataList = null;
    }

    /// <summary>
    /// 实例化新登录角色.
    /// </summary>
    private void CreateNewPlayer()
    {
        GameObject prefab = Resources.Load<GameObject>(userData.ModelInfo.ModelName);
        Vector3 pos = new Vector3(
                userData.PositionInfo.Pos_X,
                userData.PositionInfo.Pos_Y,
                userData.PositionInfo.Pos_Z
            );
        Vector3 rot = new Vector3(
                userData.PositionInfo.Rot_X,
                userData.PositionInfo.Rot_Y,
                userData.PositionInfo.Rot_Z
            );
        Color color = new Color(
                userData.ModelInfo.R,
                userData.ModelInfo.G,
                userData.ModelInfo.B
            );

        GameObject player = GameObject.Instantiate<GameObject>(prefab, pos, Quaternion.Euler(rot));
        GameObject ui = CreateFollowUI(player);
        player.GetComponent<PlayerController>().FollowUI = ui;
        ui.GetComponent<UIFollowPlayer>().SetText(userData.UserName);
        player.GetComponent<Transform>().SetParent(CityPlayerManager.Instance.M_Transform);
        //player.GetComponent<MeshRenderer>().material.color = color;

        CityPlayer cityPlayer = new CityPlayer(userData, player);
        CityPlayerManager.Instance.Add(userData.ID, cityPlayer);

        userData = null;
    }

    /// <summary>
    /// 角色模型移动.
    /// </summary>
    private void PlayerMove()
    {
        CityPlayer cityPlayer = CityPlayerManager.Instance.GetCityPlayerByID(move.ID);
        PlayerController playerController = cityPlayer.Player.GetComponent<PlayerController>();
        playerController.Move(move.X, move.Y, move.Z);
        move = null;
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
    /// 角色退出.
    /// </summary>
    private void PlayerExit()
    {
        CityPlayer cityPlayer = CityPlayerManager.Instance.GetCityPlayerByID(exitID);
        GameObject.Destroy(cityPlayer.Player.GetComponent<PlayerController>().FollowUI);
        GameObject.Destroy(cityPlayer.Player);
        CityPlayerManager.Instance.Remove(exitID);
        exitID = 0;
    }

    /// <summary>
    /// 多个角色退出.
    /// </summary>
    private void PlayersExit()
    {
        for (int i = 0; i < ids.Length; i++)
        {
            exitID = ids[i];
            PlayerExit();
        }
        ids = null;
    }

    /// <summary>
    /// 进入竞技场.
    /// </summary>
    private void EnterArena()
    {
        SceneManager.LoadScene("Game_Arena");
    }
}
