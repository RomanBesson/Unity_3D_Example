using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player_transform;
    private Vector3 offset;

    void Start()
    {
        player_transform = GameObject.Find("Player").GetComponent<Transform>();
        offset = new Vector3(3.46f, 9.35f, -4.03f);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player_transform.position + offset, Time.deltaTime * 2);
    }
}
