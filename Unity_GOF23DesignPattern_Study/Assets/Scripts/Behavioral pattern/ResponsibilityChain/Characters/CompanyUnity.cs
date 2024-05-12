using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyUnity : CompanyHandler {

    public override void HandlerRequest(string info)
    {
        if (info == "代码有BUG")
        {
            Debug.Log("程序员修改BUG");
        }
        else if (info == "代码需要热更新")
        {
            Debug.Log("程序员负责代码热更新的相关工作.");
        }
        else if (NextHandler != null)
        {
            NextHandler.HandlerRequest(info);
        }
    }
}
