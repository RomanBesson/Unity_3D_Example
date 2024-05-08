using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    private Transform[] points;         //С�����ɵ�.

    private GameObject prefab_AAA;
    private GameObject prefab_BBB;

    private List<GameObject> monsterList;   //С�ֹ�����.

    private string playerName;
    void Start()
    {
        playerName = "Player";
        points = GameObject.Find("MonsteCreaterPoints").GetComponent<Transform>().GetComponentsInChildren<Transform>();

        prefab_AAA = Resources.Load<GameObject>("Moster(Close)");
        prefab_BBB = Resources.Load<GameObject>("Moster(Long)");
        
        monsterList = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CreateAllMonster();
        }
    }

    /// <summary>
    /// ��������С��.
    /// </summary>
    private void CreateAllMonster()
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
    /// ���ɵ���С��.
    /// </summary>
    private void CreateMonster(GameObject prefab, Vector3 pos, float dis)
    {
        GameObject temp = GameObject.Instantiate(prefab, pos, Quaternion.identity);
        //��̬�ĸ�С����ӽű�.
        Monster monster = temp.AddComponent<Monster>();
        //����׷�ٺ���
        monster.SetTarget(playerName, dis);
        //�ڳ�����Դ�����Ϲ�������ɵ�С��.
        temp.GetComponent<Transform>().SetParent(transform);
        Debug.Log(temp.name);
        //��ʵ����������С����ӵ������н��й���.
        monsterList.Add(temp);
    }

    /// <summary>
    /// ����С�ֵĴ洢����.
    /// </summary>
    public void UpdateMonsterList(GameObject go)
    {
        monsterList.Remove(go);
        Debug.Log("��ǰ������С�ֵ�����:" + monsterList.Count);
    }


}
