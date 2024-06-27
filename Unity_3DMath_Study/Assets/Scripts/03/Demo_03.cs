using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_03 : MonoBehaviour {

	void Start () {
        Vector2 v2 = new Vector2(10, 5);
        Vector3 v3 = new Vector3(2, 3, 4);
        Vector4 v4 = new Vector4(1, 2, 3, 4);

        Debug.Log(v2);
        Debug.Log(v3);
        Debug.Log(v4);

        Debug.Log(v4[0]);
        Debug.Log(v4[1]);
        Debug.Log(v4[2]);
        Debug.Log(v4[3]);
	}
	
}
