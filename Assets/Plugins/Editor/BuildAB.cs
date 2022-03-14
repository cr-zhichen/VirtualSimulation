/*****************************************

    文件：BuildAB.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/14 13:47:39
    功能：AB包打包工具

******************************************/
using System.IO;
using UnityEditor;
using UnityEngine;
 
public class BuildAB : MonoBehaviour {
 
    //[MenuItem("AssetBundle/Package (Default)")]
    [MenuItem("Ccrui/打包AB包")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
