/*****************************************

    文件：Screenshots.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/15 13:52:4
    功能：截图类

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshots : MonoBehaviour
{
    /// <summary>
    /// 截图
    /// </summary>
    /// <param name="renderTexture"></param>
    /// <returns></returns>
    public static string StartScreenshots(RenderTexture renderTexture)
    {
        RenderTexture prev = RenderTexture.active;
        RenderTexture.active = renderTexture;
        Texture2D png = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        png.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        byte[] bytes = png.EncodeToPNG();
        string strbaser64 = Convert.ToBase64String(bytes);
        return strbaser64;
    }
}
