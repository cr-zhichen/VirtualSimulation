/*****************************************

    文件：TextManager.cs
    作者：程瑞
    邮箱：296529530@qq.com
    日期：2021/12/29 14:20:50
    功能：保存场景中所有文字

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{

    public static TextManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [Header("场景中全部文字")] [Tooltip("全局字体")] public Font font;
    [Tooltip("全局字体样式")] public FontStyle fontStyle;

    public List<TextData> textData;


    private void OnValidate()
    {
        foreach (TextData data in textData)
        {
            try
            {
                data.gameObject.text = data.text;
                data.temporaryText = data.text;

                //判断列表中字体是否为空 若为空 字体为总字体 为不为空 字体为列表中字体
                data.gameObject.GetComponent<Text>().font = data.font == null ? font : data.font;
                //判断列表中是否使用非全局字体样式
                data.gameObject.GetComponent<Text>().fontStyle = data.isFontStyle ? data.fontStyle : fontStyle;
            }
            catch
            {
                Debug.LogError("请检查是否未赋值");
            }
        }
    }
}

//数据类
[System.Serializable]
public class TextData
{
    public Text gameObject; //文字数据
    [Tooltip("字体为空时使用全局字体")] public Font font;
    [Tooltip("false=使用全局样式\ntrue=使用列表样式")] public bool isFontStyle;
    public FontStyle fontStyle;
    [HideInInspector] public string temporaryText; //临时文字数据

    [TextArea] [Tooltip("文字为空时 显示Text组件文字")]
    public string text; //文字数据
}