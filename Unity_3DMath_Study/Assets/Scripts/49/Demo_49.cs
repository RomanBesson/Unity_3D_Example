using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Demo_49 : MonoBehaviour {

	private Transform m_Transform;


	void Start () {
		m_Transform = gameObject.GetComponent<Transform>();

	}
	

	void Update () {


		//m_Transform.rotation = Quaternion.Euler(Vector3.Lerp(m_Transform.rotation.eulerAngles, new Vector3(100, 0, 0), 0.02f));
		//m_Transform.rotation = Quaternion.Lerp(m_Transform.rotation, Quaternion.Euler(120, 0, 0), 0.02f);

		//m_Transform.DORotate(new Vector3(100, 0, 0), 1);
		m_Transform.DORotateQuaternion(Quaternion.Euler(new Vector3(100, 0, 0)), 1);

        if (Input.GetKeyDown(KeyCode.Space))
        {
			//m_Transform.Rotate(Vector3.forward, 10);
			//Debug.Log("四元数:" + m_Transform.rotation + "欧拉角:" + m_Transform.rotation.eulerAngles);
        }


	}
}
