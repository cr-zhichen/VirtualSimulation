/*****************************************

    文件：Loding.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/15 0:6:18
    功能：登录

******************************************/
using System.Collections;
using System.Collections.Generic;
using LitJson;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loding : MonoBehaviour
{

    public InputField emailText;
    public InputField password;

    private string url = "https://localhost:7129/api/Users/Loding";
    
    public void StartLoding()
    {

        JsonData jsonData = new JsonData();
        jsonData["Md5Email"]= Md5.ToCalculateMd5(emailText.text);
        jsonData["Md5Password"]=Md5.ToCalculateMd5(password.text);
        

        var webRequest=GameManager.Instance.GetComponent<WebRequest>();
        webRequest.Post(url,new WebRequest.HttpHelperPostGetCallbacks((code, request, rsponse) =>
        {
            
            if (rsponse.code==200)
            {
                var a=JsonConvert.DeserializeObject<rsponseOK>(rsponse.text);
                GameManager.Instance.userData.openId = Md5.ToCalculateMd5(emailText.text);
                GameManager.Instance.userData.email = emailText.text;
                GameManager.Instance.userData.password = password.text;
                GameManager.Instance.userData.token = a.token;
                SceneManager.LoadScene("VirtualSimulation");
            }
            else
            {
                Debug.LogWarning(rsponse.text);
            }
        }),jsonData);
    }

    class rsponseOK
    {
        public string token;
    }
    
}
