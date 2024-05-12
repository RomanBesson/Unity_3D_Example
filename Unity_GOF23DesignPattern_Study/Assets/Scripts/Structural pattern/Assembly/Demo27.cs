using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo27 : MonoBehaviour {

    private GameObject prefab_PlayerA;
    private GameObject prefab_PlayerB;
    private GameObject prefab_PlayerC;

	void Start () {
        prefab_PlayerA = Resources.Load<GameObject>("Players/PlayerA");
        prefab_PlayerB = Resources.Load<GameObject>("Players/PlayerB");
        prefab_PlayerC = Resources.Load<GameObject>("Players/PlayerC");

        PlayerA p1 = GameObject.Instantiate<GameObject>(prefab_PlayerA).GetComponent<PlayerA>();
        p1.name = "p1";
        p1.InitPlayer(100);
        Debug.Log("p1角色的生命值:" + p1.GetHP());

        PlayerB p2 = GameObject.Instantiate<GameObject>(prefab_PlayerB).GetComponent<PlayerB>();
        p2.name = "p2";
        p2.InitPlayer(110);

        PlayerC p3 = GameObject.Instantiate<GameObject>(prefab_PlayerC).GetComponent<PlayerC>();
        p3.name = "p3";
        p3.InitPlayer(120);

        PlayerA p4 = GameObject.Instantiate<GameObject>(prefab_PlayerA).GetComponent<PlayerA>();
        p4.name = "p4";
        p4.InitPlayer(100);

        PlayerB p5 = GameObject.Instantiate<GameObject>(prefab_PlayerB).GetComponent<PlayerB>();
        p5.name = "p5";
        p5.InitPlayer(110);

        PlayerC p6 = GameObject.Instantiate<GameObject>(prefab_PlayerC).GetComponent<PlayerC>();
        p6.name = "p6";
        p6.InitPlayer(120);

        Team teamA = new GameObject("TeamA").AddComponent<Team>();
        teamA.Add(p1);
        teamA.Add(p2);
        Debug.Log("TeamA团队是生命值:" + teamA.GetHP());

        Team teamB = new GameObject("TeamB").AddComponent<Team>();
        teamB.Add(p3);
        teamB.Add(p4);

        Team teamC = new GameObject("TeamC").AddComponent<Team>();
        teamC.Add(p5);
        teamC.Add(p6);

        Team teamD = new GameObject("TeamD").AddComponent<Team>();
        teamD.Add(teamA);
        teamD.Add(teamB);
        teamD.Add(teamC);

        PlayerA monkey = GameObject.Instantiate<GameObject>(prefab_PlayerA).GetComponent<PlayerA>();
        monkey.name = "monkey";
        monkey.InitPlayer(100);

        Team teamE = new GameObject("TeamE").AddComponent<Team>();
        teamE.Add(monkey);
        teamE.Add(teamD);
        //teamE.Remove(monkey);

	}
}
