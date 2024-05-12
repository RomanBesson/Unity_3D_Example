using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Decorator {

    private Player player;
    public Player Player
    {
        get { return player; }
        set { player = value; }
    }

    public void SetDecorator(Player player)
    {
        this.player = player;
    }

}
