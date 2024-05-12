using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : PlayerBase, ITeam {

    private List<PlayerBase> playerList = new List<PlayerBase>();

    private Transform m_Transform;

    void Awake()
    {
        m_Transform = gameObject.GetComponent<Transform>();
    }

    public void Add(PlayerBase player)
    {
        if (!playerList.Contains(player))
        {
            playerList.Add(player);
            player.GetComponent<Transform>().SetParent(m_Transform);
        }
            
    }

    public void Remove(PlayerBase player)
    {
        if (playerList.Contains(player))
        {
            playerList.Remove(player);
            player.GetComponent<Transform>().SetParent(null);
        }
    }

    public override int GetHP()
    {
        int sum = 0;
        for (int i = 0; i < playerList.Count; i++)
        {
            sum += playerList[i].GetHP();
        }
        return sum;
    }
}
