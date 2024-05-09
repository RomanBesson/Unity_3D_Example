using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 角色运动的控制脚本
/// </summary>
public class PlayerMoveByMouse : MonoBehaviour
{
    private Ray ray;
    private RaycastHit raycastHit;
    private NavMeshAgent navMeshAgent;
    public GameObject prefab_Arrow;
    private Animator animator;

    void Start()
    {
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
        //获取鼠标点击位置
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
  
        //判断是左键点击之后再导航，否则会一直跟着鼠标
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out raycastHit))
            {
                //设置目的地
                navMeshAgent.SetDestination(raycastHit.point);
                //生成箭头特效
                CreateArrow(raycastHit.point);
            }
        }
      
    }

    /// <summary>
    /// 创建箭头特效
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
    /// 切换常态和跑步
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
