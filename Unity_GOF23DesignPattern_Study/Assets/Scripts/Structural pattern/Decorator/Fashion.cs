using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fashion {

    //衣服集合
    private Dictionary<int, Color32> colors = null;

    public Fashion()
    {
        colors = new Dictionary<int, Color32>();
        colors.Add(1, Color.red);
        colors.Add(2, Color.green);
        colors.Add(3, Color.blue);
        colors.Add(4, Color.yellow);
    }

    public void SetFashion(int id, Player player)
    {
        Color32 temp;
        colors.TryGetValue(id, out temp);
        player.Color = temp;
    }
}
