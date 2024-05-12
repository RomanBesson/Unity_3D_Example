using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_31 : MonoBehaviour {


	void Start () {

        MyDebug.Log("普通信息.");

        MyDebug.LogWarning("警告信息.");

        MyDebug.LogError("错误信息.");
	}
	

}
