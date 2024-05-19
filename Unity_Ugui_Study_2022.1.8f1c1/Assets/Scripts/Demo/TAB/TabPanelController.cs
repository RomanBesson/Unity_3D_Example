using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabPanelController : MonoBehaviour {

    private Transform m_Transform;
    private Transform tab_Transform;
    private Transform content_Transform;

    private Image[] tabs;
    private Image[] contents;

	void Start () {
        FindInit();
        ResetTab(1);

	}

    /// <summary>
    /// 基本物体的查找.
    /// </summary>
    private void FindInit()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        tab_Transform = m_Transform.Find("Tabs").GetComponent<Transform>();
        content_Transform = m_Transform.Find("Contents").GetComponent<Transform>();

        tabs = tab_Transform.GetComponentsInChildren<Image>();
        contents = content_Transform.GetComponentsInChildren<Image>();
    }

    /// <summary>
    /// 重置选项卡.
    /// </summary>
    private void ResetTab(int index)
    {
        for (int i = 1; i < contents.Length; i++)
        {
            contents[i].gameObject.SetActive(false);
            tabs[i].color = Color.white;
        }
        contents[index].gameObject.SetActive(true);
        tabs[index].color = Color.green;
    }
}
