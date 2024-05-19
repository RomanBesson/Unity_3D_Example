using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 签到面板Item元素数据实体类.
/// </summary>
/// </summary>
public class ItemDao
{

    private string itemName;    //名称.
    private string itemRank;    //等级.
    private int itemNum;        //数量.

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }

    public string ItemRank
    {
        get { return itemRank; }
        set { itemRank = value; }
    }

    public int ItemNum
    {
        get { return itemNum; }
        set { itemNum = value; }
    }

    public override string ToString()
    {
        return string.Format("名称:{0},等级:{1},数量:{2}", this.itemName, this.itemRank, this.itemNum);
    }
}
