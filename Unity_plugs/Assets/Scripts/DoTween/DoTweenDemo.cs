using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

/// <summary>
/// 注入的方式使用DoTween
/// </summary>
public class DoTweenDemo : MonoBehaviour {

    private Transform cube_Transform;
    private Image m_Image;
    private RectTransform m_RectTransform;

	void Start () {
        cube_Transform = GameObject.Find("Cube").GetComponent<Transform>();
        m_Image = GameObject.Find("Image").GetComponent<Image>();
        m_RectTransform = GameObject.Find("Image").GetComponent<RectTransform>();

        CubeAnimation();
        UIAnimation();
	}
	
    /// <summary>
    /// UI动画.
    /// </summary>
    private void UIAnimation()
    {
        //m_Image.DOColor(Color.green, 5);
        //m_Image.DOFade(0.2f, 2);
       // m_RectTransform.DOScale(200, 1).SetLoops(2).OnComplete(()=>Debug.Log("图片缩放完毕."));
       
    }

    /// <summary>
    /// 模型动画.
    /// </summary>
    private void CubeAnimation()
    {
        //DOMove.
        cube_Transform.DOMove(new Vector3(0, 5, 0), 1);
        cube_Transform.DOMoveX(3.5f, 2);

        //DORotate.
        //cube_Transform.DORotate(new Vector3(0, 180, 0), 2);

        //DOScale.
        //cube_Transform.DOScale(3, 1);
        //cube_Transform.DOScaleX(20, 2);

    }
}
