using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 线流动动画
/// </summary>
public class LineEffect : MonoBehaviour
{
    private float speed = 0.5f;
    private Material material;

    void Start()
    {
        material = gameObject.GetComponent<LineRenderer>().material; 
    }

    void Update()
    {
        float x = Time.time * speed;
        material.SetTextureOffset("_MainTex", new Vector2(x, 0));
    }
}
