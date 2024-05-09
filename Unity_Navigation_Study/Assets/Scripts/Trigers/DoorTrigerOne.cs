using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigerOne : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        MonsterManager.Instance.CreateAllMonster();
        HouseManager.Instance.ToWallOff(1);
        Destroy(gameObject);
    }
}
