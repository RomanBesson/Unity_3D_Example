using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabItem : MonoBehaviour {

    private Button m_Button;
    private int index;

	void Start () {
        m_Button = gameObject.GetComponent<Button>();
        index = int.Parse(gameObject.name.Substring(gameObject.name.Length - 1, 1));
        m_Button.onClick.AddListener(OnClick);
	}

    private void OnClick()
    {
        SendMessageUpwards("ResetTab", index);
    }

}
