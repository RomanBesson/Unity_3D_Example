using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollowPlayer : MonoBehaviour {

    private Transform m_Transform;
    private Transform playerTransform = null;
    public Transform PlayerTransform { set { playerTransform = value; } }

    private Text text;

    void Awake()
    {
        text = gameObject.GetComponent<Text>();
    }

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
	}
	

	void Update () {
		if(playerTransform != null)
        {
            Vector2 pos = RectTransformUtility.WorldToScreenPoint(Camera.main, playerTransform.position);
            m_Transform.position = pos + new Vector2(0, 100);
        }
	}

    /// <summary>
    /// 设置Text组件内容.
    /// </summary>
    public void SetText(string name)
    {
        text.text = name;
    }

}
