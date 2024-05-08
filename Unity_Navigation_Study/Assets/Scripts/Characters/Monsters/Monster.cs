using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private NavMeshAgent m_NavMeshAgent;

    private Transform player_Transform;     //��������ģ�͵�Transform.

    private float distance;                 //����.

    private bool alive = true;              //С�ֵ�һ�����״̬.

    public bool Alive
    {
        get { return alive; }
        set
        { 
            alive = value;
            //����С�ֹ���������
            SendMessageUpwards("UpdateMonsterList", gameObject);
        }
    }
    void Awake()
    {
        m_NavMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// ������ʼĿ�ĵ��Լ�С��׷��
    /// </summary>
    /// <param name="playerName"></param>
    /// <param name="dis"></param>
    public void SetTarget(string playerName, float dis)
    {
        player_Transform = GameObject.Find(playerName).GetComponent<Transform>();
        m_NavMeshAgent.SetDestination(player_Transform.position);

        //����С�ֵ�ֹͣ����.
        distance = dis;
        m_NavMeshAgent.stoppingDistance = distance;

        StartCoroutine("FollowNavigation");
    }

    /// <summary>
    /// ���浼��.
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
