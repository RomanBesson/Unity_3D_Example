using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_06 : MonoBehaviour {

    private Transform m_Transform;
    private Transform cubeB_Transform;

	void Start () {
        Vector3 v1 = new Vector3(12, 8, 7);
        Vector3 v2 = new Vector3(5, 3, 2);
        //Debug.Log(v1 + v2);
        //Debug.Log(v1 - v2);
        
        Debug.Log(Vector3.Distance(v1, v2));
	}


    private void Demo1()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        cubeB_Transform = GameObject.Find("CubeB").GetComponent<Transform>();

        Vector3 tempV3 = -3 * cubeB_Transform.position;
        Debug.Log(tempV3);
        m_Transform.position = tempV3;
    }
}
