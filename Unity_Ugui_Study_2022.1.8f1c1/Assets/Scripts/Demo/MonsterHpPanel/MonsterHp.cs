using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterHp : MonoBehaviour
{
    /// <summary>
    /// 血条跟随
    /// </summary>
    public void Follow(Vector3 position)
    {
        //小怪在2d屏幕上的位置
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, position);
        transform.position = screenPos + new Vector2(0, 70);//偏移量硬编码，待修改
    }
}
