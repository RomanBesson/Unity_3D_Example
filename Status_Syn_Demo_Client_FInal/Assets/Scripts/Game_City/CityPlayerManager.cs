using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 主城角色管理器.
/// </summary>
public class CityPlayerManager : MonoBehaviour {

    public static CityPlayerManager Instance;
    private Dictionary<int, CityPlayer> cityPlayerDic = new Dictionary<int, CityPlayer>();

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
        cityPlayerDic.Add(id, cityPlayer);
    }

    /// <summary>
    /// 移除数据.
    /// </summary>
    public void Remove(int id)
    {
        cityPlayerDic.Remove(id);
    }

    /// <summary>
    /// 通过ID获取CityPlayer对象.
    /// </summary>
    /// <param name="id"></param>
    public CityPlayer GetCityPlayerByID(int id)
    {
        CityPlayer temp;
        if (cityPlayerDic.TryGetValue(id, out temp))
        {
            return temp;
        }
        else
        {
            return null;
        }
    }
}
