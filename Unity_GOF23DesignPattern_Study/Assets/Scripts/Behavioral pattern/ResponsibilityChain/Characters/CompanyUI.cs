using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyUI : CompanyHandler {

    public override void HandlerRequest(string info)
    {
        if (info == "制作UI")
        {
            Debug.Log("UI工作人员使用PS制作UI.");
        }
        else if (info == "调整图标尺寸")
        {
            Debug.Log("UI工作人员调整图标尺寸.");
        }
        else if (NextHandler != null)
        {
            NextHandler.HandlerRequest(info);
        }
    }
}
