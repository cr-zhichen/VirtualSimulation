/*****************************************

    文件：WebRequest.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/15 0:10:16
    功能：网络请求

******************************************/

using System.Collections.Generic;
using UnityEngine;

namespace Tool
{
    
    public class Data
    {
        /// <summary>
        /// Token
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// Gruop
        /// </summary>
        public int @group { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string messass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string image { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ab { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
    }

    public class ReturnClass
    {
        /// <summary>
        /// 返回状态码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string messass { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public Data data { get; set; }
    }

    public class ReturnClassList
    {
        /// <summary>
        /// 返回状态码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string messass { get; set; }
        /// <summary>
        /// 返回数据列表
        /// </summary>
        public List <Data> data { get; set; }
    }

}