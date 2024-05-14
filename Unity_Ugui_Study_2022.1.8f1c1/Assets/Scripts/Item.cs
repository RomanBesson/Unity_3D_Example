using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    private Transform m_Transform;
    private Text m_MaxNum;
    private Text m_MinNum;

	void Awake () {
        m_Transform = gameObject.GetComponent<Transform>();
        m_MaxNum = m_Transform.Find("MaxNum").GetComponent<Text>();
        m_MinNum = m_Transform.Find("MinNum").GetComponent<Text>();
	}

    public void SetItemValue(int maxValue, int minValue)
    {
        m_MaxNum.text = maxValue.ToString();
        m_MinNum.text = minValue.ToString();
    }
}
