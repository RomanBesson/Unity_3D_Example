using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backpack : MonoBehaviour {

    private GameObject prefab_Item;
    private RectTransform m_RectTransform;

	void Start () {
        prefab_Item = Resources.Load<GameObject>("Item");
        m_RectTransform = GameObject.Find("Grid").GetComponent<RectTransform>();
        CreateAllItem();
	}


    private void CreateAllItem()
    {
        for (int i = 0; i < 50; i++)
        {
            Item item = GameObject.Instantiate<GameObject>(prefab_Item, m_RectTransform).GetComponent<Item>();
            item.SetItemValue(Random.Range(10, 100), Random.Range(1, 10));
        }
    }

}
