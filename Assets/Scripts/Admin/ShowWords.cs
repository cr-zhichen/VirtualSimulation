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
using UnityEngine;
using UnityEngine.UI;

public class ShowWords : MonoBehaviour
{
    private Text _text;
    private void Awake()
    {
        _text = GetComponent<Text>();
        EventCenter.AddListener<string>(ENventType.ShowWords,ShowText);
    }

    private void ShowText(string s)
    {
        _text.text = s;
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<string>(ENventType.ShowWords,ShowText);
    }
}
