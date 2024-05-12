using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FU_TankCFactory : FU_ITankFactory
{

    public FU_TankBase CreateTank(GameObject prefab)
    {
        FU_TankBase tankBase = GameObject.Instantiate<GameObject>(prefab).GetComponent<FU_TankBase>();
        tankBase.InitTank(2, 100);
        return tankBase;
    }
}
