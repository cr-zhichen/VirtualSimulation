/*****************************************

    文件：LoadDataAB.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/15 16:52:29
    功能：从服务器获取AB包列表

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class LoadDataAB : MonoBehaviour
{

    private string url = "api/Users/ShowABPackage";

    public List<ShowABPackageReturn> showAbPackageReturns;

    public GameObject displayBoxContent;
    public List<GameObject> displayBoxContentList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    private void Awake()
    {
        EventCenter.AddListener(ENventType.UpdateData,UpdateData);
    }

    /// <summary>
    /// 更新链接
    /// </summary>
    public void UpdateData()
    {
        foreach (var displayBox in displayBoxContentList)
        {
            displayBox.GetComponent<DisplayBoxContent>().UpdateAB();
            Destroy(displayBox);
        }

        displayBoxContentList = new List<GameObject>();
        
        Load();
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(ENventType.UpdateData,UpdateData);
    }

    /// <summary>
    /// 加载链接
    /// </summary>
    public void Load()
    {

        JsonData jsonData = new JsonData();
        jsonData["openid"] = GameManager.Instance.userData.openId;
        jsonData["password"] = Md5.ToCalculateMd5(GameManager.Instance.userData.password);
        
        var webRequest = GameManager.Instance.GetComponent<WebRequest>();
        webRequest.Post(GameManager.Instance.url+url,new WebRequest.HttpHelperPostGetCallbacks((code, request, rsponse) =>
        {
            Debug.Log(rsponse.text);

            if (rsponse.code==200)
            {
                var a=JsonConvert.DeserializeObject<Tool.ReturnClassList>(rsponse.text);
            
                // Debug.Log(a.data);

                foreach (var data in a.data)
                {
                    var _showABPackageReturn =new ShowABPackageReturn
                    {
                        Id = data.id,
                        Name = data.name,
                        Image = "https://kai.chengrui.xyz/VirtualSimulation/Image/" + data.image,
                        AB = "https://kai.chengrui.xyz/VirtualSimulation/AssetBundles/" + data.ab,
                        Group = data.group
                    };
                    showAbPackageReturns.Add(_showABPackageReturn);

                    GameObject g = Instantiate(displayBoxContent, this.transform);
                    displayBoxContentList.Add(g);
                    g.GetComponent<Toggle>().group = this.GetComponent<ToggleGroup>();
                    g.GetComponent<DisplayBoxContent>().showAbPackageReturn = _showABPackageReturn;

                }
                
            }
            else
            {
                var a=JsonConvert.DeserializeObject<Tool.ReturnClassList>(rsponse.text);
                Notice.Instance.AccordingToNotice(a.messass,Color.red, true,null);


            }
            
            
        }),jsonData,GameManager.Instance.userData.token);
    }

    /// <summary>
    /// 广播加载选定AB包
    /// </summary>
    public void LoadSelectedABPackage()
    {
        EventCenter.Broadcast(ENventType.LoadChooseToAB);
    }

    /// <summary>
    /// 广播删除AB包
    /// </summary>
    public void RemoveABPackage()
    {
        EventCenter.Broadcast(ENventType.RemoveABPackage);
    }
    
    [System.Serializable]
    public class ShowABPackageReturn
    {
        public long Id ;
        public string Name;
        public string Image;
        public string AB ;
        public int Group;
    }
    
}
