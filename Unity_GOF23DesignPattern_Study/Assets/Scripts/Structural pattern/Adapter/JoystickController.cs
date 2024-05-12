using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 原来的配置控制
/// </summary>
public class JoystickController : MonoBehaviour {

	void Update () {
        Controller();
	}

    private void Controller()
    {
        if(Input.GetKeyDown(KeyCode.Joystick8Button2))
        {
            PlayerMove();
        }

        if(Input.GetKeyDown(KeyCode.Joystick7Button19))
        {
            Attack_1();
        }

        if (Input.GetKeyDown(KeyCode.Joystick7Button15))
        {
            Attack_2();
        }

        if (Input.GetKeyDown(KeyCode.Joystick7Button12))
        {
            Jump();
        }
    }


    public void PlayerMove()
    {
        Debug.Log("控制角色移动.");
    }

    public void Attack_1()
    {
        Debug.Log("第一种攻击方式.");
    }

    public void Attack_2()
    {
        Debug.Log("第二种攻击方式.");
    }

    public void Jump()
    {
        Debug.Log("控制玩家角色跳跃.");
    }
}
