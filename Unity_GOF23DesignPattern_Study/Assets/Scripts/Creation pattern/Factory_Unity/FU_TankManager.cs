using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FU_TankManager : MonoBehaviour
{

    private GameObject prefab_TankA;
    private GameObject prefab_TankB;
    private GameObject prefab_TankC;
    private GameObject prefab_TankD;

    private List<string> tankNames;

    void Start()
    {
        prefab_TankA = Resources.Load<GameObject>("Tanks/TankA");
        prefab_TankB = Resources.Load<GameObject>("Tanks/TankB");
        prefab_TankC = Resources.Load<GameObject>("Tanks/TankC");
        prefab_TankD = Resources.Load<GameObject>("Tanks/TankD");

      
        tankNames = new List<string>();
        tankNames.Add("TankA");
        tankNames.Add("TankB");
        tankNames.Add("TankC");
        tankNames.Add("TankD");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = Random.Range(0, tankNames.Count);
            FU_ITankFactory tankFactory = null;
            FU_TankBase tank = null;
            switch (tankNames[index])
            {
                case "TankA":
                    tankFactory = new FU_TankAFactory();
                    tank = tankFactory.CreateTank(prefab_TankA);
                    break;
                case "TankB":
                    tankFactory = new FU_TankBFactory();
                    tank = tankFactory.CreateTank(prefab_TankB);
                    break;
                case "TankC":
                    tankFactory = new FU_TankCFactory();
                    tank = tankFactory.CreateTank(prefab_TankC);
                    break;
                case "TankD":
                    tankFactory = new FU_TankDFactory();
                    tank = tankFactory.CreateTank(prefab_TankD);
                    break;
            }
            tank.TankMove();
            tank.TankShoot();
            Debug.Log(tank.ToString());
        }


    }


}
