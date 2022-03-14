/*****************************************

    文件：Md5.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/15 1:0:18
    功能：计算Md5

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Md5
{
    /// <summary>
    /// MD5加密
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToCalculateMd5(string str)
    {
        var md5 = MD5.Create();
        var result = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
        var strResult = BitConverter.ToString(result);
        string result3 = strResult.Replace("-", "");
        return result3;
    }
}
