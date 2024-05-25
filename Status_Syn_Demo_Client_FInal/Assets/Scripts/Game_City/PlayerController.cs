using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SocketDLL;
using SocketDLL.Message;

public enum PlayerState
{
    Idle,
    Walk,
    Attack
}


public class PlayerController : MonoBehaviour {

    private Transform m_Transform;
    private NavMeshAgent m_NavMeshAgent;
    private Animator m_Animator;
    private GameObject followUI;
    public GameObject FollowUI
    {
        get { return followUI; }
        set { followUI = value; }
    }
    private PlayerState playerState = PlayerState.Idle;
    private bool isAttack = false;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        m_NavMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        m_Animator = gameObject.GetComponent<Animator>();
	}

    void Update()
    {
        if(playerState == PlayerState.Walk)
        {
            if(Mathf.Abs(m_NavMeshAgent.remainingDistance) < 0.01f)
            {
                m_Animator.SetBool("Walk", false);
                playerState = PlayerState.Idle;
            }
        }
    }

    /// <summary>
    /// 竞技场伤害请求.
    /// </summary>
    private void HitMessage()
    {
        SocketMessage message = new SocketMessage();
        message.Head = MessageHead.CS_Hit;
        message.Body = ArenaPlayerManager.Instance.GetIDByGameObject(this.gameObject);
        byte[] bytes = SocketTools.Serialize(message);
        MKAsyncClient.Instance.Send(bytes);
    }

    /// <summary>
    /// 使用导航组件移动到指定位置.
    /// </summary>
    public void Move(float x, float y, float z)
    {
        m_NavMeshAgent.SetDestination(new Vector3(x, y, z));
        m_Animator.SetBool("Walk", true);
        playerState = PlayerState.Walk;
    }

    /// <summary>
    /// 攻击动画.
    /// </summary>
    public void Attack()
    {
        m_Animator.SetTrigger("Attack");
    }

    /// <summary>
    /// 被攻击动画.
    /// </summary>
    public void Hit()
    {
        m_Animator.SetTrigger("Hit");
    }


    /// <summary>
    /// 武器触发判定事件.
    /// </summary>
    private void OnTriggerEnter(Collider coll)
    {
        if(playerState == PlayerState.Attack && coll.gameObject != this.gameObject && isAttack)
        {
            if (ArenaPlayerManager.Instance.CurrentID == ArenaPlayerManager.Instance.GetIDByGameObject(this.gameObject))
            {
                //攻击到了对方角色.
                isAttack = false;
                HitMessage();
                Debug.Log("攻击到了对方.");
            }
        }

    }

    private void EnterAttack()
    {
        playerState = PlayerState.Attack;
        isAttack = true;
    }

    private void ExitAttack()
    {
        playerState = PlayerState.Idle;
    }

}
