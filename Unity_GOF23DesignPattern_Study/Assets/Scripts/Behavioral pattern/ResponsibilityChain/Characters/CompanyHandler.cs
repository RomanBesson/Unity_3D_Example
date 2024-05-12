using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CompanyHandler : MonoBehaviour {

    private CompanyHandler nextHandler;

    public CompanyHandler NextHandler
    {
        get { return nextHandler; }
        set { nextHandler = value; }
    }

    public abstract void HandlerRequest(string info);
}
