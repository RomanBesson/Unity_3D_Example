using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerA : PlayerBase {

    private int baseHP = 10;
    private int levelHP = 0;

    public void InitPlayer(int hp)
    {
        this.levelHP = hp;
    }

    public override int GetHP()
    {
        return baseHP + levelHP;
    }
}
