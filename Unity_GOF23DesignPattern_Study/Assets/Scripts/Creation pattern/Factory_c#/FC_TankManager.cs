using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//生成坦克
public class FC_TankManager : MonoBehaviour
{

    private List<string> tankNames;

    void Start()
    {
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
            //随机生成
            int index = Random.Range(0, tankNames.Count);
            FC_ITankFactory tankFactory = null;
            switch (tankNames[index])
            {
                case "TankA":
                    tankFactory = new FC_TankAFactory();
                    break;
                case "TankB":
                    tankFactory = new FC_TankBFactory();
                    break;
                case "TankC":
                    tankFactory = new FC_TankCFactory();
                    break;
                case "TankD":
                    tankFactory = new FC_TankDFactory();
                    break;
            }

            FC_TankBase tank = tankFactory.CreateTank();
            tank.TankMove();
            tank.TankShoot();
            Debug.Log(tank.ToString());


        }



    }
}


