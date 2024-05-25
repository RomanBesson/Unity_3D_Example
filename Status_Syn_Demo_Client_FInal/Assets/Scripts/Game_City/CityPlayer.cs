using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketDLL;
using SocketDLL.Message;

public class CityPlayer {

    private UserData userData;
    private GameObject player;
    private UserInfoView userInfoView;

    public UserData UserData
    {
        get { return userData; }
        set { userData = value; }
    }

    public GameObject Player
    {
        get { return player; }
        set { player = value; }
    }

    public UserInfoView UserInfoView
    {
        get { return userInfoView; }
        set { userInfoView = value; }
    }

    public CityPlayer(UserData data)
    {
        this.userData = data;
    }

    public CityPlayer(UserData data, GameObject player)
    {
        this.userData = data;
        this.player = player;
    }

    public CityPlayer(UserData data, UserInfoView view)
    {
        this.userData = data;
        this.userInfoView = view;
    }

    public CityPlayer(UserData data, GameObject player, UserInfoView view)
    {
        this.userData = data;
        this.player = player;
        this.userInfoView = view;
    }

}
