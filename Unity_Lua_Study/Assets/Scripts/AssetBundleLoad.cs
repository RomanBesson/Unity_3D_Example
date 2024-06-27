using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 测试读取本地的AssetBundle文件.
/// </summary>
public class AssetBundleLoad : MonoBehaviour {

	void Start () {
       //AssetBundle ab = AssetBundle.LoadFromFile(Application.dataPath + "/AssetBundles/player/player1.ab");
        AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/player/player1.ab");

        //读取到了AssetBundle文件
        if (ab != null)
       {
         GameObject player = ab.LoadAsset<GameObject>("Necromancer");
         GameObject.Instantiate<GameObject>(player, Vector3.zero, Quaternion.identity);
       }
       else
       {
           GameObject cube = Resources.Load<GameObject>("Cube");
           GameObject.Instantiate<GameObject>(cube, Vector3.zero, Quaternion.identity);
       }
	}

}
