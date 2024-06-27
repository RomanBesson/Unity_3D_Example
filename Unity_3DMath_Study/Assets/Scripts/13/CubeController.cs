using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    private Transform m_Transform;
    private Transform camera_Transform;
    private MeshRenderer m_MeshRenderer;
    private BoxCollider m_BoxCollider;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        camera_Transform = GameObject.Find("Main Camera").GetComponent<Transform>();
        m_MeshRenderer = gameObject.GetComponent<MeshRenderer>();
        m_BoxCollider = gameObject.GetComponent<BoxCollider>();
	}
	
	void Update () {
        float angle = Vector3.Angle(m_Transform.position, camera_Transform.forward);
        if (angle < 60)
        {
            m_MeshRenderer.enabled = true;
            m_BoxCollider.enabled = true;
        }
        else if (angle > 60)
        {
            m_MeshRenderer.enabled = false;
            m_BoxCollider.enabled = false;
        }

	}
}
