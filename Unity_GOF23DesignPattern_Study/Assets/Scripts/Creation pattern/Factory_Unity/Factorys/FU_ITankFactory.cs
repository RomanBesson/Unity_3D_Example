using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface FU_ITankFactory
{
    FU_TankBase CreateTank(GameObject prefab);
}