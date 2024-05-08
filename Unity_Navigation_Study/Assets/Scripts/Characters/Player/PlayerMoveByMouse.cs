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
    public GameObject prefab_Arrow;
    private Animator animator;

    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        IdleOrRun();
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
                //���ɼ�ͷ��Ч
                CreateArrow(raycastHit.point);
            }
        }
      
    }

    /// <summary>
    /// ������ͷ��Ч
    /// </summary>
    /// <param name="point"></param>
    private void CreateArrow(Vector3 point)
    {
        point = point + new Vector3(0, 0.5f, 0);
        GameObject ga = Instantiate(prefab_Arrow, point, Quaternion.identity);
        ga.GetComponent<ArrowEffectManager>().PlayEffects();
        Destroy(ga, 1);
    }

    /// <summary>
    /// �л���̬���ܲ�
    /// </summary>
    private void IdleOrRun()
    {
        if (Mathf.Abs(navMeshAgent.remainingDistance) >= 0.1f)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }

}
