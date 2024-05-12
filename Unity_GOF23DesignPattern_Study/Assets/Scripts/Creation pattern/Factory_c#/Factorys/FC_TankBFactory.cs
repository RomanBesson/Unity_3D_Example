using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FC_TankBFactory : FC_ITankFactory
{

    public FC_TankBase CreateTank()
    {
        return new FC_TankB(6, 300);
    }
}
