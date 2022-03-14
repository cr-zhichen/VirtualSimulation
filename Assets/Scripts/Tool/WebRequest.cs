/*****************************************

    文件：WebRequest.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/15 0:10:16
    功能：网络请求

******************************************/
using LitJson;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequest : MonoBehaviour
{
    public delegate void HttpHelperPostGetCallbacks(long code, HttpHelperRequests request, HttpHelperResponses rsponse);

    //Http请求信息
    [Serializable]
    public struct HttpHelperRequests
    {
        //请求地址
        public string url;
        //表单字段
        public JsonData filelds;
        //表头
        public JsonData headers;
        public string token;
        public string session;
    }

    //Http返回信息
    [Serializable]
    public struct HttpHelperResponses
    {
        //返回Http状态码
        public long code;
        //返回http提示信息
        public string message;
        //请求接口时返回的头字典
        public Dictionary<string, string> headers;
        //请求API接口时返回的文本内容
        public string text;
        //请求返回的字节数值
        public byte[] bytes;
        //下载完成时返回的Texture
        public Texture texture;
        //下载资源时用到的线程
        public Thread thread;
        //下载的AB
        public AssetBundle bundle;

        /// <summary>
        /// 将text反序列化成T类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Deserialize<T>()
        {
            return JsonConvert.DeserializeObject<T>(this.text);
        }
    }

    #region UnityWebRequest
    private void SendRequest(string url, HttpHelperPostGetCallbacks callback, JsonData fields = null, JsonData header = null, int timeout = 5)
    {
        StartCoroutine(_SendRequest(url, callback, fields, header, timeout));
    }

    IEnumerator _SendRequest(string url, HttpHelperPostGetCallbacks callback, JsonData fields = null, JsonData header = null, int timeout = 5)
    {
        using (UnityWebRequest webRequest = new UnityWebRequest(url))
        {
            webRequest.timeout = timeout;
            yield return webRequest.SendWebRequest();

            //组装 请求信息
            HttpHelperRequests request = new HttpHelperRequests();
            request.url = url;
            request.filelds = fields;
            request.headers = header;

            //组装 返回信息
            HttpHelperResponses response = new HttpHelperResponses();
            response.code = webRequest.responseCode;
            response.message = webRequest.error;
            response.headers = webRequest.GetResponseHeaders();
            response.text = webRequest.downloadHandler.text;
            response.bytes = webRequest.downloadHandler.data;

            //调用 委托
            callback?.Invoke(webRequest.responseCode, request, response);

            //结束 处理占用资源
            //尽快停止UnityWebRequest
            webRequest.Abort();
            //默认值是true，调用该方法不需要设置Dispose()，Unity就会自动在完成后调用Dispose()释放资源。
            webRequest.disposeDownloadHandlerOnDispose = true;
            //不再使用此UnityWebRequest，并应清理它正在使用的任何资源
            webRequest.Dispose();
        }

    }

    #endregion

    //Post方法 
    /*
     Post方法将一个表上传到远程的服务器，一般来说我们登陆某个网站的时候会用到这个方法，我们的账号密码会以一个表单的形式传过去。
    */
    
    //POST普通表单请求,支持Header,Authorization
    /// <summary>
    /// POST普通表单请求
    /// POST普通表单参数请求 - 数据以Parameters形式发送
    /// </summary>
    /// <param name="url">目标URL</param>
    /// <param name="callback">请求完成回调</param>
    /// <param name="fields">表单字段</param>
    /// <param name="header">请求头字典, 默认Content-Type=application/json</param>
    /// <param name="timeout"></param>
    public void Post(string url, HttpHelperPostGetCallbacks callback, JsonData fields = null,JsonData header = null, int timeout = 5)
    {
        StartCoroutine(_Post(url, callback, fields, header, timeout));
    }

    IEnumerator _Post(string url,HttpHelperPostGetCallbacks callback, JsonData fields = null,JsonData header = null,int timeout = 5)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Post(url,fields!=null?fields.ToJson():null))
        {
            
            byte[] bodyRaw = Encoding.UTF8.GetBytes(fields.ToJson());
            
            //设定超时
            webRequest.timeout = timeout;
            //设置请求头  根据实际需求来
            webRequest.SetRequestHeader("Authorization", "Bearer "+GameManager.Instance.userData.token);
            webRequest.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
            webRequest.SetRequestHeader("Content-Type", "application/json");
            //开始与远程服务器通信
            //等待通行完成
            yield return webRequest.SendWebRequest();

            //组装 请求信息
            HttpHelperRequests request = new HttpHelperRequests();
            request.url = url;
            request.filelds = fields;
            request.headers = header;

            //组装 返回信息
            HttpHelperResponses response = new HttpHelperResponses();
            response.code = webRequest.responseCode;
            response.message = webRequest.error;
            response.headers = webRequest.GetResponseHeaders();
            response.text = webRequest.downloadHandler.text;
            response.bytes = webRequest.downloadHandler.data;

            //调用 委托
            callback?.Invoke(webRequest.responseCode, request, response);

            //结束 处理占用资源
            //尽快停止UnityWebRequest
            webRequest.Abort();
            //默认值是true，调用该方法不需要设置Dispose()，Unity就会自动在完成后调用Dispose()释放资源。
            webRequest.disposeDownloadHandlerOnDispose = true;
            //不再使用此UnityWebRequest，并应清理它正在使用的任何资源
            webRequest.Dispose();
        }
    }

}
