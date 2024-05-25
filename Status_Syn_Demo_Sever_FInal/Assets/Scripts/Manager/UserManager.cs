using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketDLL;
using SocketDLL.Message;


public class UserManager : MonoBehaviour {

    public static UserManager Instance;
    private MKAsyncServer serverSocket;

    private List<MKClientState> clientStateList = new List<MKClientState>();    //客户端状态对象集合.
    private List<UserData> userDataList = new List<UserData>();                 //模拟用户数据.
    private List<MKClientState> cityPlayerList = new List<MKClientState>();     //主城角色对象集合.

    private Arena arena = null;             //竞技场房间对象.
    private List<MKClientState> arenaWaitList = new List<MKClientState>();      //竞技场匹配等待列表.


    public Arena Arena
    {
        get { return arena; }
    }

    public List<MKClientState> ClientStateList
    {
        get { return clientStateList; }
    }

    public List<MKClientState> CityPlayerList
    {
        get { return cityPlayerList; }
    }

    public List<MKClientState> ArenaWaitList
    {
        get { return arenaWaitList; }
    }


    void Awake()
    {
        Instance = this;
    }

	void Start () {
        InitUserData();
        serverSocket = MKAsyncServer.Instance;
        serverSocket.CloseSocketEvent += Clear;
	}

    /// <summary>
    /// 初始化竞技场房间对象.
    /// </summary>
    public int[] InitArena()
    {
        int[] tempIDs = new int[2];
        tempIDs[0] = arenaWaitList[0].UserData.ID;
        tempIDs[1] = arenaWaitList[1].UserData.ID;

        arena = new Arena(arenaWaitList[0], arenaWaitList[1]);

        cityPlayerList.Remove(arenaWaitList[0]);
        cityPlayerList.Remove(arenaWaitList[1]);

        arenaWaitList.Clear();
        return tempIDs;
    }

    /// <summary>
    /// 获取竞技场内角色对象集合.
    /// </summary>
    public List<UserData> GetArenaList()
    {
        List<UserData> userDataList = new List<UserData>();
        arena.PlayerA.UserData.PositionInfo.Pos_X = 0;
        arena.PlayerA.UserData.PositionInfo.Pos_Y = 0;
        arena.PlayerA.UserData.PositionInfo.Pos_Z = 0;

        arena.PlayerB.UserData.PositionInfo.Pos_X = 3;
        arena.PlayerB.UserData.PositionInfo.Pos_Y = 0;
        arena.PlayerB.UserData.PositionInfo.Pos_Z = 0;

        userDataList.Add(arena.PlayerA.UserData);
        userDataList.Add(arena.PlayerB.UserData);
        return userDataList;
    }

    /// <summary>
    /// 计算竞技场上角色伤害数据.
    /// </summary>
    public HitInfo CalcHit(int hitID)
    {
        HitInfo info = null;
        if(hitID == arena.PlayerA.UserData.ID)
        {
            //对PlayerB进行伤害计算.
            int id = arena.PlayerB.UserData.ID;
            arena.PlayerB.UserData.HP = arena.PlayerB.UserData.HP - 100;
            float blood = arena.PlayerB.UserData.HP / 1500.0f;
            info = new HitInfo(id, arena.PlayerB.UserData.HP, blood);
        }
        else if (hitID == arena.PlayerB.UserData.ID)
        {
            //对PlayerA进行伤害计算.
            int id = arena.PlayerA.UserData.ID;
            arena.PlayerA.UserData.HP = arena.PlayerA.UserData.HP - 100;
            float blood = arena.PlayerA.UserData.HP / 1500.0f;
            info = new HitInfo(id, arena.PlayerA.UserData.HP, blood);
        }
        return info;
    }

    /// <summary>
    /// 添加数据.
    /// </summary>
    public void Add(MKClientState state)
    {
        clientStateList.Add(state);
    }

    /// <summary>
    /// 移除数据.
    /// </summary>
    public void Remove(MKClientState state)
    {
        clientStateList.Remove(state);
    }

    /// <summary>
    /// 添加角色数据.
    /// </summary>
    public void AddPlayer(MKClientState state)
    {
        cityPlayerList.Add(state);
    }

    /// <summary>
    /// 往等待列表中添加角色.
    /// </summary>
    public bool AddWaitPlayer(MKClientState state)
    {
        arenaWaitList.Add(state);
        if(arenaWaitList.Count == 2)
        {
            Debug.Log("开启竞技场房间.");
            return true;
        }
        return false;
    }

    /// <summary>
    /// 移除角色数据.
    /// </summary>
    public void RemovePlayer(MKClientState state)
    {
        cityPlayerList.Remove(state);
    }

    /// <summary>
    /// 通过ID值,在主城集合中移除对应的角色对象.
    /// </summary>
    /// <param name="id"></param>
    public void RemovePlayerByID(int id)
    {
        for (int i = 0; i < cityPlayerList.Count; i++)
        {
            if(cityPlayerList[i].UserData.ID == id)
            {
                cityPlayerList[i].ClientSocket.Close();
                cityPlayerList.Remove(cityPlayerList[i]);
            }
        }
    }

    /// <summary>
    /// 通过用户名,获取对应的用户数据对象.
    /// </summary>
    public UserData GetUserData(string userName)
    {
        for (int i = 0; i < userDataList.Count; i++)
        {
            if (userDataList[i].UserName == userName)
            {
                return userDataList[i];
            }
        }
        return null;
    }

    /// <summary>
    /// 获取主城内所有角色的UserData.
    /// </summary>
    /// <returns></returns>
    public List<UserData> GetCityUserDataList()
    {
        List<UserData> userDataList = new List<UserData>();
        for (int i = 0; i < cityPlayerList.Count; i++)
        {
            userDataList.Add(cityPlayerList[i].UserData);
        }
        return userDataList;
    }

    /// <summary>
    /// 通过ID值,在主城角色集合中,获取对应角色的UserData.
    /// </summary>
    public UserData GetUserDataByID(int id)
    {
        for (int i = 0; i < cityPlayerList.Count; i++)
        {
            if(cityPlayerList[i].UserData.ID == id)
            {
                return cityPlayerList[i].UserData;
            }
        }
        return null;
    }


    /// <summary>
    /// 通过ID值,在主城角色集合中,获取对应角色的MKClientState.
    /// </summary>
    public MKClientState GetMKClientStateByID(int id)
    {
        for (int i = 0; i < cityPlayerList.Count; i++)
        {
            if (cityPlayerList[i].UserData.ID == id)
            {
                return cityPlayerList[i];
            }
        }
        return null;
    }


    /// <summary>
    /// 清空数据.
    /// </summary>
    private void Clear()
    {
        //客户端状态对象集合.
        for (int i = 0; i < clientStateList.Count; i++)
        {
            clientStateList[i].ClientSocket.Close();
        }
        clientStateList.Clear();

        //主城角色对象集合.
        for (int i = 0; i < cityPlayerList.Count; i++)
        {
            cityPlayerList[i].ClientSocket.Close();
        }
        cityPlayerList.Clear();

        userDataList.Clear();
    }

    /// <summary>
    /// 将指定角色--客户端状态对象集合-->主城角色对象集合.
    /// </summary>
    public bool Move(int id)
    {
        for (int i = 0; i < clientStateList.Count; i++)
        {
            if(clientStateList[i].UserData.ID == id)
            {
                cityPlayerList.Add(clientStateList[i]);
                clientStateList.Remove(clientStateList[i]);
                return true;
            }
        }
        return false;
    }



    /// <summary>
    /// 模拟用户数据,初始化.
    /// </summary>
    private void InitUserData()
    {
        userDataList.Add(new UserData(1, "monkey", "face1", 10, 1500, new PlayerModelInfo("RoyalKnight", 1, 0, 0), new PlayerPositionInfo(0, 0, 0, 0, 0, 0)));
        userDataList.Add(new UserData(2, "mkcode", "face2", 12, 1500, new PlayerModelInfo("RoyalKnight", 0, 1, 0), new PlayerPositionInfo(3, 0, 0, 0, 0, 0)));
        userDataList.Add(new UserData(3, "lkk", "face3", 14, 1500, new PlayerModelInfo("RoyalKnight", 0, 0, 1), new PlayerPositionInfo(6, 0, 0, 0, 0, 0)));
    }

}
