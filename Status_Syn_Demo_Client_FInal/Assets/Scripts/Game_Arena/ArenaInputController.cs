using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketDLL;
using SocketDLL.Message;


public class ArenaInputController : MonoBehaviour {

    private Ray ray;
    private RaycastHit hit;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                PlayerMove(hit.point);
            }
        }


        if(Input.GetKeyDown(KeyCode.F1))
        {
            PlayerAttack();
        }

    }

    /// <summary>
    /// 角色移动消息.
    /// </summary>
    private void PlayerMove(Vector3 pos)
    {
        Move move = new Move(CityPlayerManager.Instance.CurrentID, pos.x, pos.y, pos.z);
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.CS_ArenaPlayerMove;
        message.Body = move;
        byte[] bytes = SocketTools.Serialize(message);
        MKAsyncClient.Instance.Send(bytes);
    }



    /// <summary>
    /// 角色攻击消息.
    /// </summary>
    private void PlayerAttack()
    {
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.CS_ArenaPlayerAttack;
        message.Body = ArenaPlayerManager.Instance.CurrentID;
        byte[] bytes = SocketTools.Serialize(message);
        MKAsyncClient.Instance.Send(bytes);
    }


}
