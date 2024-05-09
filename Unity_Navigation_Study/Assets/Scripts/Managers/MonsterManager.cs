using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 负责小怪的管理和生成
/// </summary>
public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance;
    private Transform[] points;         //小怪生成点.

    private GameObject prefab_AAA;
    private GameObject prefab_BBB;

    private List<GameObject> monsterList;   //小怪管理集合.

    private string playerName;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        playerName = "Player";
        points = GameObject.Find("MonsteCreaterPoints").GetComponent<Transform>().GetComponentsInChildren<Transform>();

        prefab_AAA = Resources.Load<GameObject>("Monster(Goblin)");
        prefab_BBB = Resources.Load<GameObject>("Monster(Goblin)");
        
        monsterList = new List<GameObject>();
    }


    /// <summary>
    /// 生成所有小怪.
    /// </summary>
    public void CreateAllMonster()
    {
        for (int i = 1; i < points.Length; i++)
        {
            if (i <= 2)
            {
                CreateMonster(prefab_AAA, points[i].position, 2);
            }
            else
            {
                CreateMonster(prefab_BBB, points[i].position, 5);
            }
        }
    }

    /// <summary>
    /// 生成单个小怪.
    /// </summary>
    private void CreateMonster(GameObject prefab, Vector3 pos, float dis)
    {
        GameObject temp = GameObject.Instantiate(prefab, pos, Quaternion.identity);
        //动态的给小怪添加脚本.
        Monster monster = temp.AddComponent<Monster>();
        //调用追踪函数
        monster.SetTarget(playerName, dis);
        //在场景资源层面上管理好生成的小怪.
        temp.GetComponent<Transform>().SetParent(transform);
        //把实例化出来的小怪添加到集合中进行管理.
        monsterList.Add(temp);
    }

    /// <summary>
    /// 更新小怪的存储集合.
    /// </summary>
    public void UpdateMonsterList(GameObject go)
    {
        monsterList.Remove(go);
        //关卡怪物都被消灭，开启下一关
        if (monsterList.Count == 0)
        {
            HouseManager.Instance.ToWallOpen(2);
        }
    }


}
