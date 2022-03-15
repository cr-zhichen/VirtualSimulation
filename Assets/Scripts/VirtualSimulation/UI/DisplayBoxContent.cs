/*****************************************

    文件：DisplayBoxContent.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/15 22:33:33
    功能：AB包展示框

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DisplayBoxContent : MonoBehaviour
{

    public Image bg;
    private Toggle _toggle;

    public LoadDataAB.ShowABPackageReturn showAbPackageReturn;

    public delegate void DownImageOver(Sprite sprite);

    // Start is called before the first frame update
    void Start()
    {
        _toggle = GetComponent<Toggle>();
        StartCoroutine(GetTexture(new DownImageOver(sprite =>
        {
            
            bg.sprite = sprite;
        })));
    }

    private void Awake()
    {
        EventCenter.AddListener(ENventType.LoadChooseToAB,LoadChooseToAB);
    }

    private void LoadChooseToAB()
    {
        GameManager.Instance.GetComponent<ForABPackage>().DownloadABPackage(showAbPackageReturn.AB,new ForABPackage.AbPackageDownloadIsComplete(
            ab =>
            {
                Instantiate(ab.LoadAsset<GameObject>(showAbPackageReturn.Name));
            }));
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(ENventType.LoadChooseToAB,LoadChooseToAB);
    }

    /// <summary>
    /// 下载背景图
    /// </summary>
    /// <param name="downImageOver"></param>
    /// <returns></returns>
    IEnumerator GetTexture(DownImageOver downImageOver) {
        
        UnityWebRequest webRequest = UnityWebRequest.Get(showAbPackageReturn.Image);
        yield return webRequest.SendWebRequest();

        if (webRequest.isHttpError || webRequest.isNetworkError)
        {
            Debug.Log(webRequest.downloadHandler.text);
        }
        else
        {
            // 创建一个 Texture,这个尺寸要自己定
            Texture2D texture2D = new Texture2D(1024, 1024);
            // texture2D.filterMode = FilterMode.Point;//为解决下载图片白边问题
            texture2D.LoadImage(webRequest.downloadHandler.data);
            // 使用 Texture 创建一个sprite
            Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
            downImageOver(sprite);
        }
        
        
    }
    
}
