using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LoadingPanel : MonoBehaviour {

    private Image center_Image;
    private Text num_Text;
    private float loadingValue = 0;

    private void Start()
    {
        center_Image = transform.Find("Loading/Center").GetComponent<Image>();
        num_Text = transform.Find("Loading/num").GetComponent<Text>();

        StartCoroutine("SetNum");
    }

     IEnumerator SetNum()
    {
        while (loadingValue < 0.99f)
        {
            loadingValue += UnityEngine.Random.Range(0.01f, 0.1f);
            //填充属性
            center_Image.fillAmount = loadingValue;
            num_Text.text = Math.Round(loadingValue, 2) * 100 + "%";
            yield return new WaitForSeconds(0.2f);
        }
        center_Image.fillAmount = 1;
        num_Text.text = "100%";
        MyDebug.Log("加载完毕");
    }

}
