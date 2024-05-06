using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoveByMouse : MonoBehaviour
{
    private Ray ray;
    private RaycastHit raycastHit;
    private NavMeshAgent navMeshAgent;
    private Transform transform;

    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        //��ȡ�����λ��
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
  
        //�ж���������֮���ٵ����������һֱ�������
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out raycastHit))
            {
                //����Ŀ�ĵ�
                navMeshAgent.SetDestination(raycastHit.point);
            }
        }
      
    }
}
