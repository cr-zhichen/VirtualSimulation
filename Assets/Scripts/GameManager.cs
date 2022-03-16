/*****************************************

    文件：GameManager.cs
    作者：程瑞
    邮箱：296529530@qq.com
    日期：NULL
    功能：保存场景内全部全局变量 做单例使用

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        SceneManager.LoadScene("Login");
    }

    [HeaderAttribute("用户信息")]
    public UserData userData;

    [HeaderAttribute("相机目标")]
    public CamaraTarget camaraTarget;

    [HeaderAttribute("相机基本参数")]
    public CamaraParameter camaraParameter;

    [HeaderAttribute("相机操作")]
    public CamaraOperation camaraOperation;

    [HeaderAttribute("相机位置限制")]
    public CamaraLocationLimit camaraLocationLimit;

    [HeaderAttribute("相机固定位置(第0位勿修改与删除)")]
    public List<CamaraTr> camaraTransform;

    [HeaderAttribute("地面控制")] 
    public GroundShader groundShader;

    /// <summary>
    /// 用户信息
    /// </summary>
    [System.Serializable]
    public class UserData
    {
        public string openId;
        public string email;
        public string password;
        public string token;
        public int group;
    }
    
    /// <summary>
    /// 相机目标
    /// </summary>
    [System.Serializable]
    public class CamaraTarget
    {
        public GameObject prefab;
        public Transform target;
    }
    
    /// <summary>
    /// 相机基本参数
    /// </summary>
    [System.Serializable]
    public class CamaraParameter
    {
        public GameObject cameraGameObject;//相机物体
        public Vector3 cameraPosition;//相机位置
        public Quaternion cameraRotate;//相机旋转
        public float cameraDistance;//相机距离
    }
    
    /// <summary>
    /// 相机操作
    /// </summary>
    [System.Serializable]
    public class CamaraOperation
    {
        public bool cameraAutoRotate;//是否自动旋转
        public float noOperationHomingCameraAutoRotate;//无操作自动归位自动旋转时间
        public float cameraRotateSpeed; //自动旋转速度
        public float cameraMoveSpeed; //移动速度乘数
        public float cameraMAXDistance; //摄像机最大距离
        public float cameraMINDistance; //摄像机最小距离
        public float cameraZoomSpeed;//缩放速度
        public float cameraCurrentZoom;//当前缩放状态
    }
    
    /// <summary>
    /// 相机位置限制
    /// </summary>
    [System.Serializable]
    public class CamaraLocationLimit
    {
        public Vector2 camaraLimitX;//相机x轴最值
        public Vector2 camaraLimitY;//相机y轴最值
        public Vector2 camaraLimitZ;//相机z轴最值
        [Tooltip("相机上下角度设置\nX为最小，Y为最大\n-180-180度")]
        public Vector2 camaraAngle;//相机上下角度
    }
    
    /// <summary>
    /// 控制地面Shader
    /// </summary>
    [System.Serializable]
    public class GroundShader
    {
        public GameObject groundGameObject;
        [Range(0, 1)]
        public float groundSpeed;
    }
    
    /// <summary>
    /// 相机固定位置
    /// </summary>
    [System.Serializable]
    public class CamaraTr
    {
        [Tooltip("无需手动赋值，用于运行中快速查看对应UI位置\n第0位为相机初始位置")]
        public GameObject wordClickUI;//定义UI
        public Vector3 camaraPos;//相机固定位置01
        public Quaternion camaraRot;//相机固定角度01
    }

}


