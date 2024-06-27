using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo05Player : MonoBehaviour {

    private Transform m_Transform;
    private Transform dir_Transform;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        dir_Transform = GameObject.Find("Dir").GetComponent<Transform>();
	}
	
	void Update () {
        m_Transform.Translate(dir_Transform.position.normalized);

	}
}
