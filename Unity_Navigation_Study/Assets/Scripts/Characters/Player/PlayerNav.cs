using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNav : MonoBehaviour
{
    //获取
    private NavMeshAgent m_NavMeshAgent;
    private Transform end_Transform;

    void Start()
    {
        m_NavMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        end_Transform = GameObject.Find("End").GetComponent<Transform>();
        //设置导航
        m_NavMeshAgent.SetDestination(end_Transform.position);
    }
}
