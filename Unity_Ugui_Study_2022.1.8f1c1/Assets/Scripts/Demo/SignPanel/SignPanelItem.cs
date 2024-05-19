using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignPanelItem : MonoBehaviour
{
    private Image rank_Image;       //��Ʒ�ȼ�ͼ��.
    private Image item_Image;       //��Ʒͼ��.
    private Text num_Text;          //��Ʒ����.
    private GameObject mask;        //ǩ���������.
    private Button button;          //ǩ����ť

    private void Awake()
    {
        item_Image = transform.Find("Image").GetComponent<Image>();
        rank_Image = transform.GetComponent<Image>();
        num_Text = transform.Find("Num").GetComponent<Text>();
        mask = transform.Find("mask").gameObject;
        button = transform.Find("Button").GetComponent<Button>();
        mask.SetActive(false);
    }

    /// <summary>
    /// ���뵥Ԫ���ͼƬ��������Ϣ
    /// </summary>
    /// <param name="rankImage">��Ʒ�ȼ�ͼ��</param>
    /// <param name="itemImage">��Ʒͼ��</param>
    /// <param name="num">��Ʒ����</param>
    public void SetValue(string rankName, string itemName, int num, bool isSign, bool isButton)
    {
        num_Text.text = num.ToString();
        rank_Image.sprite = Resources.Load<Sprite>("Demo/SignPanel/TexTures/rank/" + rankName);
        item_Image.sprite = Resources.Load<Sprite>("Demo/SignPanel/TexTures/item/" + itemName);
        if (isSign)
        {
            mask.SetActive(true);
        }
        if (isButton)
        {
            button.onClick.AddListener(onclik);
        }
    }

    private void onclik()
    {
        mask.SetActive(true);
    }
}
