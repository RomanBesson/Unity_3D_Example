using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_16 : MonoBehaviour {

    private Transform m_Transform;
    private Transform player_Transform;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        player_Transform = GameObject.Find("Player").GetComponent<Transform>();
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
        {
            BossCtr();
        }
	}

    private void BossCtr()
    {
        //随机改变Boss角色的朝向.
        int y = Random.Range(0, 360);
        m_Transform.rotation = Quaternion.Euler(new Vector3(0, y, 0));

        //计算角度值.
        float angle = Vector3.Angle(player_Transform.position, m_Transform.forward);
        if(angle < 60)
        {
            Debug.Log("当前玩家角色在Boss的攻击范围内.");
        }
    }

}
