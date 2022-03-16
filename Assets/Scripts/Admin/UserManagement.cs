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
using UnityEngine;
using UnityEngine.UI;

public class UserManagement : MonoBehaviour
{
    private string _url = "https://localhost:7129/api/Users/GetUserInformation";

    public GameObject userPrefab;
    public List<GameObject> users = new List<GameObject>();

    public List<UserData> UserDatas = new List<UserData>();

    private void Start()
    {
        var webRequest= GameManager.Instance.GetComponent<WebRequest>();

        JsonData jsonData = new JsonData();
        jsonData["adminOpenId"] = GameManager.Instance.userData.openId;
        jsonData["adminPassword"] =  Md5.ToCalculateMd5(GameManager.Instance.userData.password);
        
        webRequest.Post(_url,new WebRequest.HttpHelperPostGetCallbacks((code, request, rsponse) =>
        {
            Debug.Log(rsponse.text);
            
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
