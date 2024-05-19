using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class SignPanel : MonoBehaviour
{
    //储存读取的json对象
    private List<ItemDao> itemDaos = new List<ItemDao>();
    //布局组件的位置
    private Transform grid_Transform;
    //单个背包物体的预制体
    private GameObject prefab_Item;

    void Start()
    {

        grid_Transform = transform.Find("Bag/Grid").GetComponent<Transform>();
        prefab_Item = Resources.Load<GameObject>("Demo/SignPanel/Item");

        //读取json
        string jsonstr = Resources.Load<TextAsset>("Demo/SignPanel/JsonDate/SignIn_mini").text;
        JsonData jsonData = JsonMapper.ToObject(jsonstr);
        for(int i = 0; i < jsonData.Count; i++)
        {
            ItemDao itemDao = JsonMapper.ToObject<ItemDao>(jsonData[i].ToJson());
            //生成对象
            GameObject gameObject = GameObject.Instantiate(prefab_Item, grid_Transform);
            //修改对象属性
            SignPanelItem signPanelItem = gameObject.GetComponent<SignPanelItem>();
                //是否完成签到
            bool isSign = false;
            if (i < 15) isSign = true;
            //第15个可以点击
            if (i == 15) signPanelItem.SetValue(itemDao.ItemRank, itemDao.ItemName, itemDao.ItemNum, isSign, true);
            else signPanelItem.SetValue(itemDao.ItemRank, itemDao.ItemName, itemDao.ItemNum, isSign, false);

        }

    }
}
