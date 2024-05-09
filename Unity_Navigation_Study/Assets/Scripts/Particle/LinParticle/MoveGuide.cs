using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 负责特效的生成
/// </summary>
public class MoveGuide : MonoBehaviour
{
   
    public GameObject Player; //玩家
    public GameObject prefab_LineEffect;    //引导线特效.
    public GameObject prefab_TargetEffect;  //目标点特效.

    private Transform point0;
    private Transform point1;

    //生成的线和导航点特效
    private GameObject targetEffect;
    private GameObject lineEffect;

    void Start()
    {
        point0 = transform.Find("point0").GetComponent<Transform>();
        point1 = transform.Find("point1").GetComponent<Transform>();
        CreateEffect(Player.transform.position, point0.position);
    }

   
    /// <summary>
    /// 生成导航线
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    private void CreateEffect(Vector3 start, Vector3 end)
    {
        //生成对应物体
        targetEffect = Instantiate(prefab_TargetEffect, end, Quaternion.identity);
        lineEffect = Instantiate(prefab_LineEffect, end, Quaternion.identity);
        lineEffect.GetComponent<LineRenderer>().SetPosition(0, start);
        lineEffect.GetComponent<LineRenderer>().SetPosition(1, end);
    }

    /// <summary>
    /// 接收子物体传来的信息，进行线的销毁和新线的创建
    /// </summary>
    /// <param name="id"></param>
    private void TriggerEnter(object id)
    {
        int index = (int)id;
        if (index == 0)
        {
            Destroy(targetEffect);
            Destroy(lineEffect);
            //在玩家和和点位置划线
            CreateEffect(Player.transform.position, point1.position);
        }
        else if (index == 1)
        {
            //打开大门1
            HouseManager.Instance.ToWallOpen(1);
            Destroy(targetEffect);
            Destroy(lineEffect);
        }
    }
}
