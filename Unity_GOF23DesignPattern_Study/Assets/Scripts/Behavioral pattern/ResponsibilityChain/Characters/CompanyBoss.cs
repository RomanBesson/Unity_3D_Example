using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyBoss : CompanyHandler {

    public override void HandlerRequest(string info)
    {
        if(info == "放假")
        {
            Debug.Log("老板考虑一下是否放假.");
        }
        else if(info == "加薪")
        {
            Debug.Log("老板说不加薪.");
        }else if(NextHandler != null)
        {
            NextHandler.HandlerRequest(info);
        }

    }
}
