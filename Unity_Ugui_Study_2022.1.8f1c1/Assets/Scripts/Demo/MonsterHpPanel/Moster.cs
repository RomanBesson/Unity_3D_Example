using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moster : MonoBehaviour
{
    void Update()
    {
        Move();//可优化成协程执行
    }

    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 offPos = new Vector3(horizontal, 0, vertical);
        transform.position = transform.position + offPos * 0.1f;
    }
}
