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
    public static string StartScreenshots(Camera cameraForScreenShot)
    {
        
        
        
        var oldT = RenderTexture.active;
        var renderTextureTmp = RenderTexture.GetTemporary(256, 256, 32);
        RenderTexture.active = cameraForScreenShot.targetTexture = renderTextureTmp;
        cameraForScreenShot.Render();       
        var tmpTexture2D = new Texture2D(cameraForScreenShot.targetTexture.width, cameraForScreenShot.targetTexture.height);
        tmpTexture2D.ReadPixels(new Rect(0, 0, cameraForScreenShot.targetTexture.width, cameraForScreenShot.targetTexture.height), 0, 0);
        tmpTexture2D.Apply();
        
        // RenderTexture prev = RenderTexture.active;
        // RenderTexture.active = renderTexture;
        // Texture2D png = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        // png.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        byte[] bytes = tmpTexture2D.EncodeToPNG();
        string strbaser64 = Convert.ToBase64String(bytes);
        
        Destroy(tmpTexture2D);
        RenderTexture.active = oldT;
        cameraForScreenShot.targetTexture = null;
        RenderTexture.ReleaseTemporary(renderTextureTmp);
        
        return strbaser64;
    }
}
