using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 管理者
/// </summary>
public class CompanyManager : MonoBehaviour {

    private CompanyBoss boss;
    private CompanyUnity unity;
    private CompanyArt art;
    private CompanyUI ui;

	void Awake () {
        boss = GameObject.Find("Boss").GetComponent<CompanyBoss>();
        unity = GameObject.Find("Unity").GetComponent<CompanyUnity>();
        art = GameObject.Find("Art").GetComponent<CompanyArt>();
        ui = GameObject.Find("UI").GetComponent<CompanyUI>();

        boss.NextHandler = unity;
        unity.NextHandler = art;
        art.NextHandler = ui;

        //Handler("加薪");
	}

    public void Handler(string info)
    {
        boss.HandlerRequest(info);
    }

}
