/*****************************************

    文件：UserManagement.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/16 23:11:44
    功能：用户管理

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using Newtonsoft.Json;
using Tool;
using UnityEngine;
using UnityEngine.UI;

public class UserManagement : MonoBehaviour
{
    private string _url = "api/Users/GetUserInformation";

    public GameObject userPrefab;
    public List<GameObject> users = new List<GameObject>();

    public List<UserData> UserDatas = new List<UserData>();

    private void Awake()
    {
        EventCenter.AddListener(ENventType.UpdateData,UpdateAllUserData);
        EventCenter.AddListener(ENventType.UpdateAllUserData,UpdateAllUserData);
    }

    private void UpdateAllUserData()
    {
        foreach (var _user in users)
        {
            Destroy(_user);
        }

        users = new List<GameObject>();
        UserDatas = new List<UserData>();
        LoadingUserData();
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(ENventType.UpdateData,UpdateAllUserData);
        EventCenter.RemoveListener(ENventType.UpdateAllUserData,UpdateAllUserData);
    }

    private void Start()
    {
        LoadingUserData();
    }

    /// <summary>
    /// 加载用户数据
    /// </summary>
    private void LoadingUserData()
    {
        var webRequest= GameManager.Instance.GetComponent<WebRequest>();

        JsonData jsonData = new JsonData();
        jsonData["adminOpenId"] = GameManager.Instance.userData.openId;
        jsonData["adminPassword"] =  Md5.ToCalculateMd5(GameManager.Instance.userData.password);
        
        webRequest.Post(GameManager.Instance.url+_url,new WebRequest.HttpHelperPostGetCallbacks((code, request, rsponse) =>
        {
            Debug.Log(rsponse.text);

            if (rsponse.code==200)
            {
                var a=JsonConvert.DeserializeObject<Tool.ReturnClassList>(rsponse.text);

                foreach (var _data in a.data)
                {
                    GameObject g= Instantiate(userPrefab,this.transform);
                    users.Add(g);

                    g.GetComponent<Toggle>().group = this.GetComponent<ToggleGroup>();
                    g.GetComponent<UserDataBox>().email.text = _data.email;
                    g.GetComponent<UserDataBox>().@group.text = _data.@group.ToString();

                
                    UserDatas.Add(new UserData
                    {
                        openID = _data.openID,
                        email = _data.email,
                        @group = _data.@group,
                    });
                }
                
            }
            else
            {
                try
                {
                    var a=JsonConvert.DeserializeObject<ReturnClassList>(rsponse.text);
                    Notice.Instance.AccordingToNotice(a.messass,Color.red, true,null);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Notice.Instance.AccordingToNotice("登陆失败 请检查服务器链接",Color.red, true,null);
                    throw;
                }

            }
            
            
            
        }),jsonData,GameManager.Instance.userData.token);
    }
    
    [System.Serializable]
    public class UserData
    {

        public string openID;

        public string email;

        public int @group;
    }
}
