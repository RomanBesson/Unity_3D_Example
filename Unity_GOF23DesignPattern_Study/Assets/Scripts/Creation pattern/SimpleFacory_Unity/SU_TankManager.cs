using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SU_TankManager : MonoBehaviour
{

    private SU_TankFactory m_TankFactory;
    private List<string> tankName;

    void Start()
    {
        m_TankFactory = gameObject.GetComponent<SU_TankFactory>();
        tankName = new List<string>();
        tankName.Add("TankA");
        tankName.Add("TankB");
        tankName.Add("TankC");
    }

    void Update()
    {
        //随机生成
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = Random.Range(0, tankName.Count);
            //CreateTank(tankNames[index]);
            SU_TankBase tb = m_TankFactory.CreateTank(tankName[index]);
            tb.TankMove();
            tb.TankShoot();
            Debug.Log(tb.ToString());
        }


    }

    

}
