using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Color32 color;
    public Color32 Color
    {
        get { return color; }
        set { 
            color = value;
            SetColor(color);
        }
    }

    public void SetColor(Color32 color)
    {
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }

}
