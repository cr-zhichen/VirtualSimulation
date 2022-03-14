/*****************************************

    文件：ForABPackage.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/14 16:57:11
    功能：获取AB包

******************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForABPackage : MonoBehaviour
{

    private delegate void AbPackageDownloadIsComplete(AssetBundle AB);
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstantiateObject("https://kai.chengrui.xyz/VirtualSimulation/AssetBundles/bicycle",
            new AbPackageDownloadIsComplete(
                ab =>
                {
                    Instantiate(ab.LoadAsset<GameObject>("自行车 Variant"));
                    Debug.Log("加载完成");
                })));
    }

    /// <summary>
    /// Web加载AB包
    /// </summary>
    /// <returns></returns>
    IEnumerator InstantiateObject(string _url,AbPackageDownloadIsComplete abPackageDownloadIsComplete)
    {
        Debug.Log("正在加载模型");
        string url = _url;        
        var request 
            = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle(url, 0);
        yield return request.Send();
        AssetBundle bundle = UnityEngine.Networking.DownloadHandlerAssetBundle.GetContent(request);

        abPackageDownloadIsComplete(bundle);

    }
}
