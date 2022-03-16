/*****************************************

    文件：ReturnToLandingInterface.cs
    作者：张程瑞
    邮箱：296529530@qq.com
    日期：2022/3/17 1:45:11
    功能：返回登陆界面

******************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToLandingInterface : MonoBehaviour
{
    public void StartRetrun()
    {
        SceneManager.LoadScene("Login");
    }
}
