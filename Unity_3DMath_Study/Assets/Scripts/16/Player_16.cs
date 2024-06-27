using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_16 : MonoBehaviour {

    private Transform m_Transform;
    private Transform boss_Transform;

    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        boss_Transform = GameObject.Find("Boss").GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            PlayerCtr();
        }
    }

    private void PlayerCtr()
    {
        float crossY = Vector3.Cross(boss_Transform.forward, m_Transform.position).y;
        //Debug.Log("CrossY:" + crossY);
        if(crossY > 0)
        {
            Debug.Log("玩家在Boss的右侧");
            float angle = Vector3.Angle(m_Transform.position, boss_Transform.forward);
            //m_Transform.RotateAround(boss_Transform.position, Vector3.up, (180 - angle));
            StartCoroutine("RotateBoss", (180 - angle));
        }
        else if (crossY < 0)
        {
            Debug.Log("玩家在Boss的左侧");
            float angle = Vector3.Angle(m_Transform.position, boss_Transform.forward);
            //m_Transform.RotateAround(boss_Transform.position, Vector3.up, -(180 - angle));
            StartCoroutine("RotateBoss", -(180 - angle));
        }
    }


    private IEnumerator RotateBoss(float angle)
    {
        while(Vector3.Angle(m_Transform.position, -boss_Transform.forward) > 15)
        {
            yield return null;
            m_Transform.RotateAround(boss_Transform.position, Vector3.up, angle * Time.deltaTime);
            m_Transform.LookAt(boss_Transform);
        }
    }

}
