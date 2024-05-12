using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 外观模式外观类
/// </summary>
public class FacadeTools {

    public static string GetXML()
    {
        return XMLTools.GetXML();
    }

    public static string GetJSON()
    {
        JSONManager jm = new JSONManager();
        return jm.ReadJSON();
    }

    public static string GetText()
    {
        return WenBenChaoZuo.DuQuWenBen();
    }
}
