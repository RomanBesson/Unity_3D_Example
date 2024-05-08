using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    //������Ч����
    public GameObject prefab_Trap;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Trap(transform.position, prefab_Trap);
        }
    }

    /// <summary>
    /// ���弼��,��T���ͷ�.
    /// </summary>
    private void Trap(Vector3 pos, GameObject effect)
    {
        GameObject temp = GameObject.Instantiate(effect, pos + new Vector3(0, 0.3f, 0), Quaternion.identity);
        //����ײ��������ű�
        temp.AddComponent<Trap>();
        SphereCollider sc = temp.AddComponent<SphereCollider>();
        sc.isTrigger = true;
        sc.radius = 0.8f;
        //�ݻ�
        GameObject.Destroy(temp, 5);
    }

}
