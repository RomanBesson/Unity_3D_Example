using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 管理者方法，用于挂载生成坦克
/// </summary>
public class TankManager : MonoBehaviour
{

    private List<string> tankNames;

    void Start()
    {
        tankNames = new List<string>();
        tankNames.Add("TankA");
        tankNames.Add("TankB");
        tankNames.Add("TankC");
    }

    void Update()
    {
        //按下空格创建坦克
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = Random.Range(0, tankNames.Count);
            //工厂创建坦克
            TankBase tb = TankFactory.CreateTank(tankNames[index]);
            tb.TankMove();
            tb.TankShoot();
            Debug.Log(tb.ToString());
        }

    }



}
