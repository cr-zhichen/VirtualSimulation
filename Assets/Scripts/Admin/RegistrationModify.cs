/*****************************************

    文件：RegistrationModify.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/17 0:32:41
    功能：注册和修改用户信息

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class RegistrationModify : MonoBehaviour
{

    public InputField email;
    public InputField password;
    public InputField group;
    
    private string _url = "https://localhost:7129/api/Users/Register";
    
    private void Awake()
    {
        EventCenter.AddListener<string,string>(ENventType.SelectedUserInformation,SelectedUserInformation);
    }

    private void SelectedUserInformation(string _email,string _group)
    {
        email.text = _email;
        password.text = null;
        @group.text = _group;
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<string,string>(ENventType.SelectedUserInformation,SelectedUserInformation);
    }

    public void StartRegistrationModify()
    {
        var webRequest= GameManager.Instance.GetComponent<WebRequest>();

        JsonData jsonData = new JsonData();
        jsonData["adminOpenId"] = GameManager.Instance.userData.openId;
        jsonData["adminPassword"] =  Md5.ToCalculateMd5(GameManager.Instance.userData.password);
        jsonData["email"] = email.text;
        jsonData["password"] = password.text;
        jsonData["group"] = @group.text;
        
        webRequest.Post(_url,new WebRequest.HttpHelperPostGetCallbacks((code, request, rsponse) =>
        {
            Debug.Log(rsponse.text);
            EventCenter.Broadcast(ENventType.UpdateAllUserData);
        }),jsonData,GameManager.Instance.userData.token);

    }
}
