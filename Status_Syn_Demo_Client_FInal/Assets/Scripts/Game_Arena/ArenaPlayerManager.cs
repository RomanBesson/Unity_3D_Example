using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaPlayerManager : MonoBehaviour {

    public static ArenaPlayerManager Instance;
    private Dictionary<int, CityPlayer> arenaPlayerDic = new Dictionary<int, CityPlayer>();

    private int currentID;          //当前角色ID值;
    public int CurrentID
    {
        get { return currentID; }
        set { currentID = value; }
    }

    private Transform m_Transform;
    public Transform M_Transform { get { return m_Transform; } }


    void Awake()
    {
        Instance = this;
        m_Transform = gameObject.GetComponent<Transform>();
    }

    /// <summary>
    /// 添加数据.
    /// </summary>
    public void Add(int id, CityPlayer cityPlayer)
    {
        arenaPlayerDic.Add(id, cityPlayer);
    }

    /// <summary>
    /// 移除数据.
    /// </summary>
    public void Remove(int id)
    {
        arenaPlayerDic.Remove(id);
    }

    /// <summary>
    /// 通过ID获取CityPlayer对象.
    /// </summary>
    /// <param name="id"></param>
    public CityPlayer GetCityPlayerByID(int id)
    {
        CityPlayer temp;
        if (arenaPlayerDic.TryGetValue(id, out temp))
        {
            return temp;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 通过游戏物体对象获取对应的ID值.
    /// </summary>
    public int GetIDByGameObject(GameObject go)
    {
        foreach (var item in arenaPlayerDic.Keys)
        {
            if(arenaPlayerDic[item].Player == go)
            {
                return arenaPlayerDic[item].UserData.ID;
            }
        }
        return 0;
    }


}
