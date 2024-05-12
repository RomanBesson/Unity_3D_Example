using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FC_TankDFactory : FC_ITankFactory
{

    public FC_TankBase CreateTank()
    {
        return new FC_TankD(6, 300);
    }
}
