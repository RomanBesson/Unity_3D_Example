using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_04 : MonoBehaviour {

    private Transform m_Transform;
    private Vector3 v3 = new Vector3(3, -5, 8);

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        Debug.Log("v3原始向量:" + v3);
        Debug.Log("v3负向量:" + -v3);
        Debug.Log("v3向量的长度:" + v3.magnitude);
	}
	

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            m_Transform.localPosition = Vector3.zero;
        }


	}
}
