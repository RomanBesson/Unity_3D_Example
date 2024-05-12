using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 现在的配置控制
/// </summary>
public class PCController : MonoBehaviour {

    private JoystickController m_JoystickController;

	void Start () {
        m_JoystickController = gameObject.GetComponent<JoystickController>();
	}
	

	void Update () {
        Controller();
	}

    private void Controller()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            m_JoystickController.PlayerMove();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            m_JoystickController.Attack_1();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            m_JoystickController.Attack_2();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            m_JoystickController.Jump();
        }
    }
}
