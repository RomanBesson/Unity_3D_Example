using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : Decorator {

    private Dictionary<int, Vector3> size = null;

    private Vector3 currentSize;

    public Title()
    {
        size = new Dictionary<int, Vector3>();
        size.Add(1, new Vector3(1, 1, 1));
        size.Add(2, new Vector3(2, 2, 2));
        size.Add(3, new Vector3(3, 3, 3));
        size.Add(4, new Vector3(4, 4, 4));
        size.Add(5, new Vector3(5, 5, 5));
    }

    public void SetTitle(int id)
    {
        Vector3 temp;
        size.TryGetValue(id, out temp);
        currentSize = temp;
        ShowTitle();
    }

    public void ShowTitle()
    {
        base.Player.GetComponent<Transform>().localScale = currentSize;
    }
}
