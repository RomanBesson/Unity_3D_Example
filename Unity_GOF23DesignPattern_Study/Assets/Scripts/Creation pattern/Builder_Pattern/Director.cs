using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 调用建造者里的方法
/// </summary>
public class Director {

    public void Construct(Builder builder)
    {
        builder.BuildAudios();
        builder.BuildEffects();
        builder.BuildBloodBar();
    }

}
