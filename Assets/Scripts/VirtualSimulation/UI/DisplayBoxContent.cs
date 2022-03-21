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
using LitJson;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DisplayBoxContent : MonoBehaviour
{

    public Image bg;
    private Toggle _toggle;

    public LoadDataAB.ShowABPackageReturn showAbPackageReturn;

    public delegate void DownImageOver(Sprite sprite);
    public delegate void AbPackageDownloadIsComplete(AssetBundle AB);

    private AssetBundle AB;
    private GameObject ABgameobject;

    private string delUrl = "api/Users/DelAB";

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
        EventCenter.AddListener(ENventType.UpdateAB,UpdateAB);
        EventCenter.AddListener(ENventType.RemoveABPackage,RemoveABPackage);
    }
    
    public void UpdateAB()
    {
        if (ABgameobject == null)
        {
            return;
        }
        Destroy(ABgameobject);
        //卸载AB包
        AB.Unload(true);
        // Destroy(AB);
    }

    /// <summary>
    /// 下载并展示AB包
    /// </summary>
    private void LoadChooseToAB()
    {
        if (_toggle.isOn)
        {

            try
            {
                if (ABgameobject == null)
                {
                    EventCenter.Broadcast(ENventType.UpdateAB);
                    Debug.Log("收到加载广播");
                    StartCoroutine(InstantiateObject(showAbPackageReturn.AB, new AbPackageDownloadIsComplete(
                        ab =>
                        {
                            AB = ab;
                            ABgameobject=Instantiate(ab.LoadAsset<GameObject>(showAbPackageReturn.Name));
                            Notice.Instance.AccordingToNotice("加载成功",Color.green, true,null);
                        })));
                }
                else
                {
                    Debug.Log("模型以被实例化");
                    Notice.Instance.AccordingToNotice("模型以被实例化",Color.green, true,null);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Notice.Instance.AccordingToNotice(e.Message,Color.red, true,null);
                throw;
            }
            
            
            
        }

    }

    /// <summary>
    /// 删除对应AB包
    /// </summary>
    private void RemoveABPackage()
    {
        if (_toggle.isOn)
        {
            Debug.Log("收到删除广播");
            var webRequest=GameManager.Instance.GetComponent<WebRequest>();

            JsonData jsonData = new JsonData();
            jsonData["adminOpenId"] = GameManager.Instance.userData.openId;
            jsonData["adminPassword"] =  Md5.ToCalculateMd5(GameManager.Instance.userData.password);
            jsonData["id"] = showAbPackageReturn.Id;
        
            // Debug.Log(delUrl);
            
            webRequest.Post(GameManager.Instance.url+delUrl,new WebRequest.HttpHelperPostGetCallbacks((code, request, rsponse) =>
            {
                Debug.Log(rsponse.text);

                if (rsponse.code==200)
                {
                    EventCenter.Broadcast(ENventType.UpdateData);
                    
                    var a=JsonConvert.DeserializeObject<Tool.ReturnClass>(rsponse.text);
                    Notice.Instance.AccordingToNotice(a.messass,Color.green, true,null);

                }
                else
                {
                    var a=JsonConvert.DeserializeObject<Tool.ReturnClass>(rsponse.text);
                    Notice.Instance.AccordingToNotice(a.messass,Color.red, true,null);

                }
                
            }),jsonData,GameManager.Instance.userData.token);
        }
        
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(ENventType.LoadChooseToAB,LoadChooseToAB);
        EventCenter.RemoveListener(ENventType.UpdateAB,UpdateAB);
        EventCenter.RemoveListener(ENventType.RemoveABPackage,RemoveABPackage);
        if (AB!=null)
        {
            AB.Unload(true);
        }
    }

    /// <summary>
    /// 点击后显示文字信息
    /// </summary>
    /// <param name="b"></param>
    public void ShowWords(bool b)
    {
        if (b)
        {
            EventCenter.Broadcast<long,string,int>(ENventType.ShowWords, showAbPackageReturn.Id,showAbPackageReturn.Name,showAbPackageReturn.Group);
        }
    }
    

    /// <summary>
    /// Web加载AB包
    /// </summary>
    /// <returns></returns>
    IEnumerator InstantiateObject(string _url,AbPackageDownloadIsComplete abPackageDownloadIsComplete)
    {
        Debug.Log($"正在加载模型：{_url}");
        GameObject _g = Notice.Instance.AccordingToNotice($"正在加载模型：{_url}", null, false, null);
        string url = _url;        
        var request 
            = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle(url, 0);
        yield return request.Send();
        AssetBundle bundle = UnityEngine.Networking.DownloadHandlerAssetBundle.GetContent(request);
        
        Notice.Instance.CloseToInform(_g);

        abPackageDownloadIsComplete(bundle);

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
