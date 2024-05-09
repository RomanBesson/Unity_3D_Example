using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    public static HouseManager Instance;
    private Transform wall_1;
    private Transform wall_2;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        wall_1 = GameObject.Find("Environment/Doors/door_1").GetComponent<Transform>();
        wall_2 = GameObject.Find("Environment/Doors/door_2").GetComponent<Transform>();
    }

    /// <summary>
    /// 开门方法
    /// </summary>
    /// <param name="wallNum"></param>
    public void ToWallOpen(int wallNum)
    {
        if (wallNum == 1)
        {
            StartCoroutine(WallOpen(wall_1));
        }
        if (wallNum == 2)
        {
            StartCoroutine(WallOpen(wall_2));
        }
    }

    /// <summary>
    /// 关门方法
    /// </summary>
    /// <param name="wallNum"></param>
    public void ToWallOff(int wallNum)
    {
        if (wallNum == 1)
        {
            StartCoroutine(WallOff(wall_1));
        }
        if (wallNum == 2)
        {
            StartCoroutine(WallOff(wall_2));
        }
    }

    /// <summary>
    /// 缓慢开门细节
    /// </summary>
    /// <param name="wall"></param>
    /// <returns></returns>
    IEnumerator WallOpen(Transform wall)
    {
        while (wall.position.y > -2.7f)
        {
            wall.position = new Vector3(wall.position.x, wall.position.y - 0.1f, wall.position.z);
            yield return new WaitForSeconds(0.05f);
        }
    }


    /// <summary>
    /// 缓慢关门细节
    /// </summary>
    /// <param name="wall"></param>
    /// <returns></returns>
    IEnumerator WallOff(Transform wall)
    {
        while (wall.position.y <= 2.27f)
        {
            wall.position = new Vector3(wall.position.x, wall.position.y + 0.1f, wall.position.z);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
