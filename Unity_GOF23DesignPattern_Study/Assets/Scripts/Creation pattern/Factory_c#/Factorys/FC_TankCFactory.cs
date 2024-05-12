using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FC_TankCFactory : FC_ITankFactory
{

    public FC_TankBase CreateTank()
    {
        return new FC_TankC(6, 300);
    }
}
