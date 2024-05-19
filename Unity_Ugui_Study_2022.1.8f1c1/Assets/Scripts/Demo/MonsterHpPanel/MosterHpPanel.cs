using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MosterHpPanel : MonoBehaviour
{
    //小怪物体
    private Transform monster;
    //血条对象
    private GameObject hp;
    private MonsterHp mosterHp;

    private Transform m_Tra;
    

    void Start()
    {
        monster = GameObject.Find("Cube").GetComponent<Transform>();
        //  m_Tra = transform.Find("MosterHp").GetComponent<Transform>();
        hp = Resources.Load<GameObject>("Demo/MosterHp/MosterHp");
        mosterHp = Instantiate(hp, transform).GetComponent<MonsterHp>();

    }

    void Update()
    {
        mosterHp.Follow(monster.position);

    }

}
