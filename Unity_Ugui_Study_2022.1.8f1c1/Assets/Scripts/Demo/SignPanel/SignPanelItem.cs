using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignPanelItem : MonoBehaviour
{
    private Image rank_Image;       //物品等级图标.
    private Image item_Image;       //物品图标.
    private Text num_Text;          //物品数量.
    private GameObject mask;        //签到后的遮罩.
    private Button button;          //签到按钮

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
    /// 传入单元格的图片和数量信息
    /// </summary>
    /// <param name="rankImage">物品等级图标</param>
    /// <param name="itemImage">物品图标</param>
    /// <param name="num">物品数量</param>
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
