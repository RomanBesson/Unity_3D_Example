using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private NavMeshAgent m_NavMeshAgent;

    private Transform player_Transform;     //持有主角模型的Transform.

    private float distance;                 //距离.

    private bool alive = true;              //小怪的一个存活状态.

    public bool Alive
    {
        get { return alive; }
        set
        { 
            alive = value;
            //告诉小怪管理器更新
            SendMessageUpwards("UpdateMonsterList", gameObject);
        }
    }
    void Awake()
    {
        m_NavMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// 设置起始目的地以及小怪追踪
    /// </summary>
    /// <param name="playerName"></param>
    /// <param name="dis"></param>
    public void SetTarget(string playerName, float dis)
    {
        player_Transform = GameObject.Find(playerName).GetComponent<Transform>();
        m_NavMeshAgent.SetDestination(player_Transform.position);

        //设置小怪的停止距离.
        distance = dis;
        m_NavMeshAgent.stoppingDistance = distance;

        StartCoroutine("FollowNavigation");
    }

    /// <summary>
    /// 跟随导航.
    /// </summary>
    IEnumerator FollowNavigation()
    {
        while (alive)
        {
            if (Vector3.Distance(transform.position, player_Transform.position) > distance)
            {
                m_NavMeshAgent.SetDestination(player_Transform.position);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

}
