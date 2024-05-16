using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystick : MonoBehaviour {

    private ETCJoystick m_Joystick;

    //CUBE.
    private Transform cube_Transform;
    private Rigidbody cube_Rigidbody;

    //MODEL.
    //private Animator m_Animator;
    //private CharacterController m_CC;
    private Transform m_Transform;

	void Start () {
        m_Joystick = gameObject.GetComponent<ETCJoystick>();
        cube_Transform = GameObject.Find("Player").GetComponent<Transform>();
        cube_Rigidbody = GameObject.Find("Player").GetComponent<Rigidbody>();

        //m_Animator = GameObject.Find("RoyalKnight").GetComponent<Animator>();
        //m_CC = GameObject.Find("RoyalKnight").GetComponent<CharacterController>();
        //m_Transform = GameObject.Find("RoyalKnight").GetComponent<Transform>();

        //调用事件函数
        m_Joystick.onMoveSpeed.AddListener(OnMoveSpeed);
       // m_Joystick.onMoveStart.AddListener(OnMoveStart);
       // m_Joystick.onMoveEnd.AddListener(OnMoveEnd);
	}

    //private void OnMoveStart()
    //{
    //    m_Animator.SetBool("walk", true);
    //}

    //private void OnMoveEnd()
    //{
    //    m_Animator.SetBool("walk", false);
    //}

    private void OnMoveSpeed(Vector2 v2)
    {
        Debug.Log(v2);
        Vector3 dir = new Vector3(v2.x, 0, v2.y) * 0.5f;
        //cube_Transform.Translate(dir); ===》Transform组件位移.
        cube_Rigidbody.MovePosition(cube_Transform.position + dir);
        //m_CC.SimpleMove(dir * 10);
       // m_Transform.LookAt(m_Transform.position + dir);
    }
}
