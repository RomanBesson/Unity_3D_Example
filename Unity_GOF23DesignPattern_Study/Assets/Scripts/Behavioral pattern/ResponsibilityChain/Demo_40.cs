using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_40 : MonoBehaviour {

    private CompanyManager manager;

	void Start () {
        manager = gameObject.GetComponent<CompanyManager>();
        //调用管理者传递
        manager.Handler("代码有BUG");
	}
	

}
