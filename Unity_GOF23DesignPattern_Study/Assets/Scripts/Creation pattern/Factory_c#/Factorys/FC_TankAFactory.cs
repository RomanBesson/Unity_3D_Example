using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FC_TankAFactory : FC_ITankFactory
{

    public FC_TankBase CreateTank()
    {
        return new FC_TankA(1, 300);
    }
}
