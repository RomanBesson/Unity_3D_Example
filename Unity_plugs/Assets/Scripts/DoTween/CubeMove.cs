using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class CubeMove : MonoBehaviour {

    private Transform m_Transform;
     
	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        m_Transform.DOMove(new Vector3(1, 3, 1), 2)
            .OnStart(() => Debug.Log("OnStart"))
            .OnPlay(() => Debug.Log("OnPlay"))
            .OnUpdate(() => Debug.Log("Upate"))
            .OnComplete(() => Debug.Log("OnComplete"));
	}
	
}
