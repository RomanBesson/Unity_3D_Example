using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
        {
            //�ж�С������
            other.GetComponent<Monster>().Alive = false;
            //�ݻ�С��
            Destroy(other.gameObject);
            //�ݻ����屾��
            Destroy(gameObject);
            
        }
    }
}
