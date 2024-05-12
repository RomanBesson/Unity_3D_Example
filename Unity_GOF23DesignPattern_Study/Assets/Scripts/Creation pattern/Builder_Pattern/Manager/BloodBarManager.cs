using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBarManager {

    private static BloodBarManager instance;
    private BloodBarManager() { }
    public static BloodBarManager Instance()
    {
        if(instance == null){
            instance = new BloodBarManager();
        }
        return instance;
    }

    public void SetBloodBar(Monster monster)
    {
        monster.BloodBar = "小怪血条" + monster.LifeValue;
    }

}
