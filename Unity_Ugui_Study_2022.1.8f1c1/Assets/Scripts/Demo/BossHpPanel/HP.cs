using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    private Image hpValue;

    private void Awake()
    {
        hpValue = transform.GetComponent<Image>();
    }

    public bool HpDecrease()
    {
        if (hpValue.fillAmount != 0)
        {
            hpValue.fillAmount -= 0.1f;
            return true;
        }
        else return false;
    }
}
