using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyArt : CompanyHandler {

    public override void HandlerRequest(string info)
    {
        if (info == "面试美术新人")
        {
            Debug.Log("主美负责面试美术新人.");
        }
        else if (NextHandler != null)
        {
            NextHandler.HandlerRequest(info);
        }
    }
}
