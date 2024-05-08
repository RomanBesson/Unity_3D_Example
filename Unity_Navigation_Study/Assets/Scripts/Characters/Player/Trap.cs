using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
        {
            //判定小怪已死
            other.GetComponent<Monster>().Alive = false;
            //摧毁小怪
            Destroy(other.gameObject);
            //摧毁陷阱本身
            Destroy(gameObject);
            
        }
    }
}
