/*****************************************

    文件：CameraRotateSpeed_UI.cs
    作者：程瑞
    邮箱：296529530@qq.com
    日期：2021/12/29 10:19:57
    功能：控制旋转速度

******************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRotateSpeed_UI : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Slider>().onValueChanged.AddListener(RotateSpeed);
    }

    private void RotateSpeed(float value)
    {
        GameManager.Instance.camaraOperation.cameraRotateSpeed = -value;
    }

}
