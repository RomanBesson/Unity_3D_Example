using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色控制技能释放的脚本
/// </summary>
public class TrapController : MonoBehaviour
{
    //陷阱特效对象
    public GameObject prefab_Trap;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Trap(transform.position, prefab_Trap);
        }
    }

    /// <summary>
    /// 陷阱技能,按T键释放.
    /// </summary>
    private void Trap(Vector3 pos, GameObject effect)
    {
        GameObject temp = GameObject.Instantiate(effect, pos + new Vector3(0, 0.3f, 0), Quaternion.identity);
        //加碰撞器和陷阱脚本
        temp.AddComponent<Trap>();
        SphereCollider sc = temp.AddComponent<SphereCollider>();
        sc.isTrigger = true;
        sc.radius = 0.8f;
        //摧毁
        GameObject.Destroy(temp, 5);
    }

}
