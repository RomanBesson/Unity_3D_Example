using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickDemo : MonoBehaviour {

    private ETCJoystick m_ETCJoystick;

	void Start () {
		m_ETCJoystick = gameObject.GetComponent<ETCJoystick>();

        //Move Events [移动事件].
        //m_ETCJoystick.onMoveStart.AddListener(OnMoveStart);
        //m_ETCJoystick.onMove.AddListener(OnMove);
        //m_ETCJoystick.onMoveSpeed.AddListener(OnMoveSpeed);
        //m_ETCJoystick.onMoveEnd.AddListener(OnMoveEnd);

        //Touch Events [触摸事件].
        //m_ETCJoystick.onTouchStart.AddListener(OnTouchStart);
        //m_ETCJoystick.onTouchUp.AddListener(OnTouchUp);

        m_ETCJoystick.OnDownUp.AddListener(OnDownUp);

        m_ETCJoystick.OnPressUp.AddListener(OnPressUp);

    }

    private void OnPressUp()
    {
        Debug.Log("OnPressUp");
    }

    private void OnDownUp()
    {
        Debug.Log("OnDownUp");
    }
    private void OnTouchStart()
    {
        Debug.Log("OnTouchStart");
    }

    private void OnTouchUp()
    {
        Debug.Log("OnTouchUp");
    }



    private void OnMoveStart()
    {
        Debug.Log("onMoveStart");
    }

    private void OnMove(Vector2 v2)
    {
        Debug.Log("OnMove:" + v2);
    }

    private void OnMoveSpeed(Vector2 v2)
    {
        Debug.Log("OnMoveSpeed" + v2);
    }

    private void OnMoveEnd()
    {
        Debug.Log("OnMoveEnd");
    }
}
