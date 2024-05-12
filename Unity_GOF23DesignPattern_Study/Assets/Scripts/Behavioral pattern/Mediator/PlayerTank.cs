using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour {

    private Transform m_Transform;
    private Rigidbody m_Rigidbody;
    private TankMediator m_TankMediator;

    private int atk = 5;

    public int ATK
    {
        get { return atk; }
    }

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
        m_TankMediator = GameObject.Find("Plane").GetComponent<TankMediator>();
	}
	
	void Update () {
        Move();
	}

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        m_Rigidbody.MovePosition(m_Transform.position + new Vector3(h, 0, v) * 0.2f);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.name == "EnvA")
        {
            m_TankMediator.Attack(coll.gameObject.name);
        }
        if (coll.gameObject.name == "EnvB")
        {
            m_TankMediator.Attack(coll.gameObject.name);
        }
        if (coll.gameObject.name == "EnvC")
        {
            m_TankMediator.Attack("EnvC");
        }
    }

}
