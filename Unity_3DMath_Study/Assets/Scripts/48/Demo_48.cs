using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_48 : MonoBehaviour {

	private Transform m_Transform;
	private Transform target_Transform;


	void Start () {
		m_Transform = gameObject.GetComponent<Transform>();
		target_Transform = GameObject.Find("B").GetComponent<Transform>();

		//m_Transform.rotation = Quaternion.LookRotation(Vector3.back);

		m_Transform.rotation = Quaternion.AngleAxis(80, Vector3.up);

	}
	

	void Update () {

		//m_Transform.position = Vector3.Lerp(m_Transform.position, target_Transform.position, 0.02f);
		//m_Transform.rotation = Quaternion.Lerp(m_Transform.rotation, target_Transform.rotation, 0.02f);

		//m_Transform.rotation = Quaternion.LookRotation(target_Transform.position);

	}
}
