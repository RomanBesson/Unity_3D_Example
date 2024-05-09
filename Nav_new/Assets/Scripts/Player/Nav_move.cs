using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav_move : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    //目的地
    public GameObject destination;

    private void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(destination.transform.position);
    }


}
