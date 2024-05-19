using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpPanel : MonoBehaviour
{
    //血条集合
    private List<HP> hps = new List<HP>();
    //当前血条
    private int index = 0;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!hps[index].HpDecrease()) if(index < 2) index++; 
            
        }
    }

    /// <summary>
    /// 初始化
    /// </summary>
    private void Init()
    {
        //存储三个HP血条脚本
        HP hp = transform.Find("GreenHP").GetComponent<HP>();
        hps.Add(hp);
        hp = transform.Find("YellowHP").GetComponent<HP>();
        hps.Add(hp);
        hp = transform.Find("RedHP").GetComponent<HP>();
        hps.Add(hp);
    }

  
}
