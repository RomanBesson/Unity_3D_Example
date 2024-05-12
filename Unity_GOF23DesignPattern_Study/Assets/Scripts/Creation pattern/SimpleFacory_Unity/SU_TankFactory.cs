using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SU_TankFactory : MonoBehaviour
{
    //坦克的预制体
    private GameObject prefab_TankA;
    private GameObject prefab_TankB;
    private GameObject prefab_TankC;

    void Start()
    {
        prefab_TankA = Resources.Load<GameObject>("Tanks/TankA");
        prefab_TankB = Resources.Load<GameObject>("Tanks/TankB");
        prefab_TankC = Resources.Load<GameObject>("Tanks/TankC");
    }

    public SU_TankBase CreateTank(string tankName)
    {
        SU_TankBase tankBase = null;
        switch (tankName)
        {
            case "TankA":
                tankBase = GameObject.Instantiate<GameObject>(prefab_TankA).GetComponent<SU_TankBase>();
                tankBase.InitTank(2, 100);
                break;
            case "TankB":
                tankBase = GameObject.Instantiate<GameObject>(prefab_TankB).GetComponent<SU_TankBase>();
                tankBase.InitTank(4, 200);
                break;
            case "TankC":
                tankBase = GameObject.Instantiate<GameObject>(prefab_TankC).GetComponent<SU_TankBase>();
                tankBase.InitTank(6, 300);
                break;
        }
        return tankBase;
    }



}
