/*****************************************

    文件：UserData.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/16 23:42:34
    功能：保存用户数据

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserDataBox : MonoBehaviour
{
    public Text email;
    public Text group;
    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    /// <summary>
    /// Toggle值改变时
    /// </summary>
    /// <param name="b"></param>
    public void Select(bool b)
    {
        if (b)
        {
            EventCenter.Broadcast<string,string>(ENventType.SelectedUserInformation,email.text,@group.text);
        }
    }
    
}
