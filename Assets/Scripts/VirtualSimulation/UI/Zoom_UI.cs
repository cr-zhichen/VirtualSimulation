/*****************************************

    文件：Zoom_UI.cs
    作者：程瑞
    邮箱：296529530@qq.com
    日期：2021/12/27 15:0:9
    功能：控制缩放 Slider值为-100，100，int

******************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom_UI : MonoBehaviour
{

    private void FixedUpdate()
    {

        if (GetComponent<Slider>().value < 0)
        {
            GetComponent<Slider>().value += 1;
            GameManager.Instance.camaraOperation.cameraCurrentZoom = GetComponent<Slider>().value / 10000;

        }
        else if (GetComponent<Slider>().value > 0)
        {
            GetComponent<Slider>().value -= 1;
            GameManager.Instance.camaraOperation.cameraCurrentZoom = GetComponent<Slider>().value / 10000;

        }
    }

}
