using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager {

    private static EffectManager instance;
    public static EffectManager Instance()
    {
        if(instance == null)
        {
            instance = new EffectManager();
        }
        return instance;
    }

    private Dictionary<int, string> effectDic = null;

    private EffectManager()
    {
        effectDic = new Dictionary<int, string>();
        effectDic.Add(1, "effect1.prefab");
        effectDic.Add(2, "effect2.prefab");
        effectDic.Add(3, "effect3.prefab");
        effectDic.Add(4, "effect4.prefab");
    }

    public void SetEffects(Monster monster)
    {
        string tempEffect = null;
        effectDic.TryGetValue(monster.Id, out tempEffect);
        monster.Effects = tempEffect;
    }
}
