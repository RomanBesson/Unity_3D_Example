using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_42 : MonoBehaviour {


	void Start () {
		TestA();
		TestB();
	}


	private void TestA()
    {
		Quaternion q1 = Quaternion.Euler(30, 50, 20);
		Quaternion q2 = Quaternion.Euler(15, 20, 25);

		Debug.Log("四元数q1:" + q1);
		Debug.Log(string.Format("四元数q1:{0}, {1}, {2}, {3}", q1.x, q1.y, q1.z, q1.w));
		Debug.Log("四元数q2:" + q2);
		Debug.Log(string.Format("四元数q2:{0}, {1}, {2}, {3}", q2.x, q2.y, q2.z, q2.w));

		Quaternion q3 = q1 * q2;
		Debug.Log("四元数:q1 * q2 = " + q3);
		Debug.Log(string.Format("四元数:q1 * q2 = {0}, {1}, {2}, {3}", q3.x, q3.y, q3.z, q3.w));
		//Debug.Log("欧拉角:q1 * q2 = " + q3.eulerAngles);
		Debug.Log("------------------------------");
	}

	private void TestB()
    {
		MyQuaternion mq1 = new MyQuaternion(0.3018924f, 0.3612836f, 0.04429623f, 0.8811203f);
		MyQuaternion mq2 = new MyQuaternion(0.162759f, 0.1402598f, 0.1891995f, 0.9581442f);

		Debug.Log("自定义四元数mq1:" + mq1);
		Debug.Log("自定义四元数mq2:" + mq2);
		Debug.Log("自定义四元数相乘 mq1 * mq2 = " + mq1 * mq2);
	}

}
