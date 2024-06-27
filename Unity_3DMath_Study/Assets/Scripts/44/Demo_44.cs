using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_44 : MonoBehaviour {

	void Start () {

		Quaternion q = Quaternion.Euler(new Vector3(45.3f, 1.52f, 65));
		Debug.Log(string.Format("四元数q:{0}, {1}, {2}, {3}", q.x, q.y, q.z, q.w));

		MyQuaternion mq = MyQuaternion.Euler(new Vector3(45.3f, 1.52f, 65));
		Debug.Log("四元数mq:" + mq);

		MyQuaternion mq1 = MyQuaternion.NewEuler(new Vector3(45.3f, 1.52f, 65));
		Debug.Log("四元数mq1:" + mq1);

	}
	

}
