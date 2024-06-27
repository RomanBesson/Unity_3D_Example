using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_03_01 : MonoBehaviour {

    private Transform m_Transform;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
	}
	

	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 v3 = new Vector3(0, 0, 10);
            m_Transform.Translate(v3);
        }

	}
}
