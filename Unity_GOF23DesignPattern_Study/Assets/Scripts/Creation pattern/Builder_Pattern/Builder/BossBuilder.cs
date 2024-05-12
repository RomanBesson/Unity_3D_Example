using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBuilder : Builder {

    private Monster boss;

    public BossBuilder(int id, string name, int value)
    {
        boss = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Monsters/Boss")).GetComponent<Monster>();
        boss.InitMonster(id, name, value);
    }

    public override void BuildAudios()
    {
        AudioManager.Instance().SetAudios(boss);
    }

    public override void BuildEffects()
    {
        EffectManager.Instance().SetEffects(boss);
    }

    public override void BuildBloodBar()
    {
        //BloodBarManager.Instance().SetBloodBar(boss);
        Debug.Log("Boss的血条是固定血条.");
    }


    public override GameObject GetResult()
    {
        return boss.gameObject;
    }
}
