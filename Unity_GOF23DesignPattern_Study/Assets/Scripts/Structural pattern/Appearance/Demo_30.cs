using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_30 : MonoBehaviour {

	void Start () {
        //Demo_1();
        Demo_2();
	}


    /// <summary>
    /// 普通情况
    /// </summary>
    private void Demo_1()
    {
        string xmlStr = XMLTools.GetXML();
        Debug.Log(xmlStr);

        JSONManager jsonManager = new JSONManager();
        string jsonStr = jsonManager.ReadJSON();
        Debug.Log(jsonStr);

        string textStr = WenBenChaoZuo.DuQuWenBen();
        Debug.Log(textStr);
    }

    /// <summary>
    /// 外观模式
    /// </summary>
    private void Demo_2()
    {
        string xml = FacadeTools.GetXML();
        Debug.Log(xml);

        string json = FacadeTools.GetJSON();
        Debug.Log(json);

        string text = FacadeTools.GetText();
        Debug.Log(text);
    }
}
