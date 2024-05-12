using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_44 : MonoBehaviour {

	void Start () {
        CalcContext context;

        Addition addition = new Addition();
        Subtrction subtraction = new Subtrction();

        //选择使用加法还是减法
        context = new CalcContext(subtraction);

        int result = context.Operation(10, 5);
        Debug.Log(result);
	}
	
}
