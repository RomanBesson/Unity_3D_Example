using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_46 : MonoBehaviour {

	void Start () {

		Quaternion q1 = Quaternion.Euler(new Vector3(10, 0, 0));
		Quaternion q2 = Quaternion.Euler(new Vector3(70, 0, 0));
		//Debug.Log(q1);
		//Debug.Log(Quaternion.Inverse(q1));
		Debug.Log((Quaternion.Inverse(q1) * q2).eulerAngles);


		MyQuaternion mq1 = MyQuaternion.NewEuler(new Vector3(10, 0, 0));
		MyQuaternion mq2 = MyQuaternion.NewEuler(new Vector3(70, 0, 0));
		//Debug.Log(mq1.Magnitude);
		//Debug.Log(mq1);
		//Debug.Log(MyQuaternion.Inverse(mq1));
		Debug.Log(MyQuaternion.Inverse(mq1) * mq2);

	}


	private void Demo1()
    {
		Quaternion q1 = Quaternion.Euler(new Vector3(0, 0, 0));
		Quaternion q2 = Quaternion.Euler(new Vector3(360, 0, 0));
		Debug.Log(Quaternion.Dot(q1, q2));

		MyQuaternion mq1 = MyQuaternion.NewEuler(new Vector3(0, 0, 0));
		MyQuaternion mq2 = MyQuaternion.NewEuler(new Vector3(360, 0, 0));
		Debug.Log(MyQuaternion.Dot(mq1, mq2));

	}

}
