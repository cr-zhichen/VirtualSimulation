/*****************************************

    文件：ShowWords.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/16 17:17:47
    功能：显示文字

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class ShowWords : MonoBehaviour
{
    public Text _text;

    
    private void Awake()
    {
        _text = GetComponent<Text>();
        EventCenter.AddListener<string>(ENventType.ShowWords,ShowText);
        EventCenter.AddListener(ENventType.UpdateData,UpdateData);
    }

    private void ShowText(string s)
    {
        _text.text = s;
    }

    private void UpdateData()
    {
        _text.text = "";
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<string>(ENventType.ShowWords,ShowText);
        EventCenter.RemoveListener(ENventType.UpdateData,UpdateData);
    }

    
    
}
