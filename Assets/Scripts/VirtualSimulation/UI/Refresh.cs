/*****************************************

    文件：Refresh.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/16 17:8:22
    功能：刷新

******************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refresh : MonoBehaviour
{
    /// <summary>
    /// 刷新
    /// </summary>
    public void StartRefresh()
    {
        EventCenter.Broadcast(ENventType.UpdateData);
        EventCenter.Broadcast(ENventType.CameraMove, 
            GameManager.Instance.camaraTransform[0].camaraPos,
            GameManager.Instance.camaraTransform[0].camaraRot);
    }
}
