using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_05 : MonoBehaviour {

	void Start () {
        Vector3 v1 = new Vector3(0, 0, 10);
        Vector3 v2 = new Vector3(0, 0, 100);
        Debug.Log("V1:" + v1.normalized);
        Debug.Log("V2:" + v2.normalized);
        Debug.Log(Vector3.forward);
	}
	

}
