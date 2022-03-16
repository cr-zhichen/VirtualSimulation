/*****************************************

    文件：UpdatedABPacketID.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/16 22:11:21
    功能：Nothing

******************************************/
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class UpdatedABPacketID : MonoBehaviour
{
    

    private string _url="https://localhost:7129/api/Users/UpdateAB";

    public InputField _id;
    public InputField @group;
    
    /// <summary>
    /// 更新用户组
    /// </summary>
    public void UpdateUserGroup()
    {
        var webRequest =GameManager.Instance.GetComponent<WebRequest>();

        JsonData jsonData = new JsonData();
        jsonData["adminOpenId"] = GameManager.Instance.userData.openId;
        jsonData["adminPassword"] =  Md5.ToCalculateMd5(GameManager.Instance.userData.password);
        jsonData["id"] = _id.text;
        jsonData["group"] = @group.text;
        
        
        webRequest.Post(_url,new WebRequest.HttpHelperPostGetCallbacks((code, request, rsponse) =>
        {
            Debug.Log(rsponse.text);
            EventCenter.Broadcast(ENventType.UpdateData);
            
        }),jsonData,GameManager.Instance.userData.token);
    }
}
