using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 竞技场实体类
/// </summary>
public class Arena {

    private MKClientState playerA;
    private MKClientState playerB;

    public MKClientState PlayerA
    {
        get { return playerA; }
        set { playerA = value; }
    }
    public MKClientState PlayerB
    {
        get { return playerB; }
        set { playerB = value; }
    }

    public Arena(MKClientState playerA, MKClientState playerB)
    {
        this.playerA = playerA;
        this.playerB = playerB;
    }
}
