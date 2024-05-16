using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchPad : MonoBehaviour {

    private ETCTouchPad m_TouchPad;

	void Start () {
        m_TouchPad = gameObject.GetComponent<ETCTouchPad>();

        /*
        //Move Events.
        m_TouchPad.onMoveStart.AddListener(() => Debug.Log("onMoveStart"));
        m_TouchPad.onMoveEnd.AddListener(() => Debug.Log("onMoveEnd"));
        m_TouchPad.onMove.AddListener((v2) => Debug.Log("onMove:" + v2));
        m_TouchPad.onMoveSpeed.AddListener((v2) => Debug.Log("onMoveSpeed:" + v2));
	    */

        //Touch Events.
        m_TouchPad.onTouchStart.AddListener(() => Debug.Log("onTouchStart"));
        m_TouchPad.onTouchUp.AddListener(() => Debug.Log("onTouchUp"));
    
    }

}
