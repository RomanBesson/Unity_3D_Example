using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{

    public int index;

    void OnTriggerEnter(Collider coll)
    {
        object id = index;
        if (coll.name == "Player")
        {
            SendMessageUpwards("TriggerEnter", id);
        }
    }
}
