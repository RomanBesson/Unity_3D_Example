using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(360 * Time.deltaTime, 0, 0));
    }
}
