using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    private Transform wall_1;
    private Transform wall_2;

    void Start()
    {
        wall_1 = GameObject.Find("Environment/Doors/door_1").GetComponent<Transform>();
        wall_2 = GameObject.Find("Environment/Doors/door_2").GetComponent<Transform>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(WallOpen(wall_1));
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(WallOpen(wall_2));
        }

    }


    IEnumerator WallOpen(Transform wall)
    {
        while (wall.position.y > -2.7f)
        {
            wall.position = new Vector3(wall.position.x, wall.position.y - 0.1f, wall.position.z);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
