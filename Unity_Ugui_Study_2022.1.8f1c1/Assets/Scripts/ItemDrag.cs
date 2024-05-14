using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    private RectTransform m_RectTransform;

	void Start () {
        m_RectTransform = gameObject.GetComponent<RectTransform>();
	}

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        ///实现拖拽图片功能
        Vector3 pos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(m_RectTransform, eventData.position, eventData.enterEventCamera, out pos);
        m_RectTransform.position = pos;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }
}
