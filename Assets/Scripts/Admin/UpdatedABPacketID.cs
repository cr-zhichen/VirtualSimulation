/*****************************************

    文件：UpdatedABPacketID.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/16 22:11:21
    功能：更新AB包id

******************************************/
using System.Collections;
using System.Collections.Generic;
using LitJson;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class UpdatedABPacketID : MonoBehaviour
{
    

    private string _url="api/Users/UpdateAB";

    public InputField _ABname;
    public InputField _id;
    public InputField @group;
    
    private void Awake()
    {
        EventCenter.AddListener<long,string,int>(ENventType.ShowWords,ShowText);
        EventCenter.AddListener(ENventType.UpdateData,UpdateData);
    }

    private void ShowText(long id,string s,int _group)
    {
        _ABname.text = s;
        _id.text = id.ToString();
        @group.text = _group.ToString();
    }

    private void UpdateData()
    {
        _id.text = null;
        _ABname.text = null;
        @group.text = null;
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<long,string,int>(ENventType.ShowWords,ShowText);
        EventCenter.RemoveListener(ENventType.UpdateData,UpdateData);
    }
    
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
        
        
        webRequest.Post(GameManager.Instance.url+_url,new WebRequest.HttpHelperPostGetCallbacks((code, request, rsponse) =>
        {
            Debug.Log(rsponse.text);

            if (rsponse.code == 200)
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
