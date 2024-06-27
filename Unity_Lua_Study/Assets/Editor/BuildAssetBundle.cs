using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildAssetBundle {

    [MenuItem("AssetBundle/打包所有的AssetBundle")]
    static void BuildAllAssetBundleNoral()
    {
        string path = Application.dataPath + "/AssetBundles";
        //BuildPipeline.BuildAssetBundles(路径, 选项, 平台);
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
        Debug.Log("AssetBundle打包完毕");
    }

    [MenuItem("AssetBundle/打包所有的AssetBundle[不压缩]")]
    static void BuildAllAssetBundleUnComper()
    {
        string path = Application.dataPath + "/AssetBundles";
        //BuildPipeline.BuildAssetBundles(路径, 选项, 平台);
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.StandaloneWindows64);
        Debug.Log("AssetBundle打包完毕");
    }


    [MenuItem("AssetBundle/打包所有的AssetBundle[LZ4]")]
    static void BuildAllAssetBundleLZ4()
    {
        string path = Application.dataPath + "/AssetBundles";
        //BuildPipeline.BuildAssetBundles(路径, 选项, 平台);
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
        Debug.Log("AssetBundle打包完毕");
    }
}
