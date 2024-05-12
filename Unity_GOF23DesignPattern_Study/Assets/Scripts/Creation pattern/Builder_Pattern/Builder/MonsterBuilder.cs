using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBuilder : Builder {

    private Monster monster;

    public MonsterBuilder(int id, string name, int value)
    {
        monster = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Monsters/Monster")).GetComponent<Monster>();
        monster.InitMonster(id, name, value);
    }

    public override void BuildAudios()
    {
        AudioManager.Instance().SetAudios(monster);
    }

    public override void BuildEffects()
    {
        EffectManager.Instance().SetEffects(monster);
    }

    public override void BuildBloodBar()
    {
        BloodBarManager.Instance().SetBloodBar(monster);
    }


    public override GameObject GetResult()
    {
        return monster.gameObject;
    }
}
