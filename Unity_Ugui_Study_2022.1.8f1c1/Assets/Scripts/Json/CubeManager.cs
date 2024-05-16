using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;
using System.IO;

public class CubeManager : MonoBehaviour {

    private Transform m_Transform;
    private Transform[] allCubeTransform;   //所有的Cube的Transform组件.
    private List<CubeItem> cubeList;        //Cube模型的集合.
    private List<CubeItem> posList;         //从Json文本中获取到的.

    private string jsonPath = null;         //json文本文件的路径地址.
    private GameObject prefab_Cube;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        cubeList = new List<CubeItem>();
        posList = new List<CubeItem>();
        //@是为了防转义
        jsonPath = Application.dataPath + @"\Resources\json.txt";
        prefab_Cube = Resources.Load<GameObject>("Cube");
	}


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            ObjectToJson();
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            JsonToObject();
        }

    }

    /// <summary>
    /// 对象转换为Json数据.
    /// </summary>
    private void ObjectToJson()
    {
        cubeList.Clear();
        //把父物体下的子物体的位置存储下来
        allCubeTransform = m_Transform.GetComponentsInChildren<Transform>();
        for (int i = 1; i < allCubeTransform.Length; i++)
        {
            //Debug.Log(allCubeTransform[i].gameObject.name);
            Vector3 pos = allCubeTransform[i].position;
            CubeItem item = new CubeItem(Math.Round(pos.x, 2).ToString(), Math.Round(pos.y, 2).ToString(), Math.Round(pos.z, 2).ToString());
            cubeList.Add(item);
        }

        //转换成json字符串
        string str = JsonMapper.ToJson(cubeList);
       // Debug.Log(str);

        //io操作，把json字符串写成txt文件
        File.Delete(jsonPath);
        StreamWriter sw = new StreamWriter(jsonPath);
        sw.Write(str);
        sw.Close();
    }


    /// <summary>
    /// JSON转换为多个对象.
    /// </summary>
    private void JsonToObject()
    {
        //读取json里的数据
        TextAsset textAsset = Resources.Load<TextAsset>("json");
        Debug.Log(textAsset.text);

        //添加到集合
        JsonData jsonData = JsonMapper.ToObject(textAsset.text);
        for (int i = 0; i < jsonData.Count; i++)
        {
            //Debug.Log(jsonData[i].ToJson());
            CubeItem item = JsonMapper.ToObject<CubeItem>(jsonData[i].ToJson());
            posList.Add(item);
        }

        for (int i = 0; i < posList.Count; i++)
        {
            Vector3 pos = new Vector3(float.Parse(posList[i].PosX), float.Parse(posList[i].PosY), float.Parse(posList[i].PosZ));
            GameObject.Instantiate<GameObject>(prefab_Cube, pos, Quaternion.identity, m_Transform);
        }

    }

}
