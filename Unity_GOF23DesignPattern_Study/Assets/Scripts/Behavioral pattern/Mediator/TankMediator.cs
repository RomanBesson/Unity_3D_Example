using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMediator : MonoBehaviour {

    private PlayerTank m_PlayerTank;
    private EnvA m_EnvA;
    private EnvB m_EnvB;
    private EnvC m_EnvC;

	void Start () {
        m_PlayerTank = GameObject.Find("PlayerTank").GetComponent<PlayerTank>();
        m_EnvA = GameObject.Find("EnvA").GetComponent<EnvA>();
        m_EnvB = GameObject.Find("EnvB").GetComponent<EnvB>();
        m_EnvC = GameObject.Find("EnvC").GetComponent<EnvC>();
	}

    public void Attack(string name)
    {
        if(name == m_EnvA.name)
        {
            m_EnvA.DamageA(m_PlayerTank.ATK);
            Debug.Log("A");
        }
        else if(name == m_EnvB.name)
        {
            m_EnvB.DamageB(m_PlayerTank.ATK);
            Debug.Log("B");
        }
        else if (name == m_EnvC.name)
        {
            m_EnvC.DamageC(m_PlayerTank.ATK);
            Debug.Log("C");
        }
    }

}
