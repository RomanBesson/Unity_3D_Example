using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

/// <summary>
/// 使用通用方式
/// </summary>
public class DoTweenObject : MonoBehaviour {

    private Transform cube_Transform;
    private Image m_Image;

	void Start () {
        cube_Transform = GameObject.Find("Cube").GetComponent<Transform>();
        m_Image = GameObject.Find("Image").GetComponent<Image>();

        //DOTween.To(() => myValue, x => myValue = x, 100, 1);

        //DOTween.To(() => cube_Transform.position, x => cube_Transform.position = x, new Vector3(3, 5, 3), 2);
        //cube_Transform.DOMove(new Vector3(4, 5, 6), 2);

        DOTween.To(() => cube_Transform.localScale, x => cube_Transform.localScale = x, new Vector3(5, 5, 5), 2);
        cube_Transform.DOScale(5, 2);

        //DOTween.To(() => m_Image.color, x => m_Image.color = x, Color.red, 2);
        //m_Image.DOColor(Color.red, 2);

        //DOTween.To(() => m_Image.color, x => m_Image.color = x, new Color(m_Image.color.r, m_Image.color.g, m_Image.color.b, 0.2f), 2);
        //m_Image.DOFade(0.5f, 2);

    }

	
}
