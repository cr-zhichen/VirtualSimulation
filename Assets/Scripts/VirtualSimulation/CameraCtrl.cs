/*****************************************

    文件：CameraCtrl.cs
    作者：程瑞
    邮箱：296529530@qq.com
    日期：NULL
    功能：控制相机的移动、旋转、缩放
         支持PC、手机
         左键旋转、右键和鼠标中间移动、滚轮移动
         单指滑动旋转、双指滑动移动、双指缩放

******************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using HedgehogTeam.EasyTouch;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CameraCtrl : MonoBehaviour
{
    public Transform _target; //获取旋转目标
    private float _time;//计时 用于手指点击后一段时间不自动旋转相机

    private void Awake()
    {
        //注册广播
        //接收相机移动位置参数
        EventCenter.AddListener<Vector3,Quaternion>(ENventType.CameraMove,CameraHoming);
    }
    private void Start()
    {
        _target = GameManager.Instance.camaraTarget.target;
        //更新相机参数到GameManager
        GameManager.Instance.camaraParameter.cameraGameObject = this.gameObject;
        var transform1 = this.transform;
        GameManager.Instance.camaraTransform[0].camaraPos = transform1.position;
        GameManager.Instance.camaraTransform[0].camaraRot = transform1.rotation;
    }
    private void OnDestroy()
    {
        //移除广播
        EventCenter.RemoveListener<Vector3, Quaternion>(ENventType.CameraMove, CameraHoming);
        
        //触摸
        //单指滑动
        EasyTouch.On_Drag -= Drag;

        //双指拖动
        EasyTouch.On_Drag2Fingers -= Drag2Fingers;

        //双指向内挤压
        EasyTouch.On_PinchIn -= PinchIn;
        //双指向外挤压
        EasyTouch.On_PinchOut -= PinchOut;
        //停止双指挤压
        EasyTouch.On_PinchEnd -= PinchEnd;
    }

    /// <summary>
    /// 更改相机位置
    /// </summary>
    /// <param name="p">相机位置</param>
    /// <param name="q">相机旋转</param>
    private void CameraHoming(Vector3 p,Quaternion q)
    {
        // Debug.Log("相机归位");
        var transform1 = this.transform;
        transform1.position = p;
        transform1.rotation = q;
    }

    private void OnEnable()
    {
        //EasyTouch 方法

        //触摸
        //单指滑动
        EasyTouch.On_Drag += Drag;

        //双指拖动
        EasyTouch.On_Drag2Fingers += Drag2Fingers;

        //双指向内挤压
        EasyTouch.On_PinchIn += PinchIn;
        //双指向外挤压
        EasyTouch.On_PinchOut += PinchOut;
        //停止双指挤压
        EasyTouch.On_PinchEnd += PinchEnd;

    }
    /// <summary>
    /// 单指滑动旋转
    /// </summary>
    /// <param name="gesture"></param>
    private void Drag(Gesture gesture)
    {
        if (EasyTouch.GetTouchCount()==1)
        {
            _time = 0;

            var x = gesture.deltaPosition.x;
            var y = gesture.deltaPosition.y;

            Rotate(x / 50, -y / 50);
        }
    }
    
    /// <summary>
    /// 双指滑动移动
    /// </summary>
    /// <param name="gesture"></param>
    private void Drag2Fingers(Gesture gesture)
    {
        if (EasyTouch.GetTouchCount() >= 2)
        {
            _time = 0;

            var x = gesture.deltaPosition.x;
            var y = gesture.deltaPosition.y;

            CameraMove(x / 50, -y / 50);
        }
        
    }

    /// <summary>
    /// 双指合拢
    /// </summary>
    /// <param name="gesture"></param>
    private void PinchIn(Gesture gesture)
    {
        GameManager.Instance.camaraOperation.cameraCurrentZoom = -0.05f;
    }
    /// <summary>
    /// 双指张开
    /// </summary>
    /// <param name="gesture"></param>
    private void PinchOut(Gesture gesture)
    {
        GameManager.Instance.camaraOperation.cameraCurrentZoom = 0.05f;
    }
    /// <summary>
    /// 结束双指缩放
    /// </summary>
    /// <param name="gesture"></param>
    private void PinchEnd(Gesture gesture)
    {
        GameManager.Instance.camaraOperation.cameraCurrentZoom = 0;

    }



    private void Update()
    {
        //控制当前是否自动旋转
        _time += Time.deltaTime;
        GameManager.Instance.camaraOperation.cameraAutoRotate = _time>=GameManager.Instance.camaraOperation.noOperationHomingCameraAutoRotate;

        //更新GameManager中相机参数
        var gameObject1 = this.gameObject;
        GameManager.Instance.camaraParameter.cameraPosition=gameObject1.transform.position;
        GameManager.Instance.camaraParameter.cameraRotate = gameObject1.transform.rotation;

    }

    private void LateUpdate()
    {

        Limit();//防止摄像机超限
        
        //相机旋转和缩放
        CameraRotate();
        CameraZoom();
    }

    /// <summary>
    /// 防止摄像机超限
    /// </summary>
    private void Limit()
    {
        if (this.transform.position.x < GameManager.Instance.camaraLocationLimit.camaraLimitX.x || this.transform.position.x > GameManager.Instance.camaraLocationLimit.camaraLimitX.y)
        {
            if (this.transform.position.x<-30)
            {
                this.transform.Translate(new Vector3(50,0,0)*Time.deltaTime,Space.World);
            }
            else
            {
                this.transform.Translate(new Vector3(-50,0,0)*Time.deltaTime,Space.World);
            }
        }
        else if (this.transform.position.y < GameManager.Instance.camaraLocationLimit.camaraLimitY.x || this.transform.position.y > GameManager.Instance.camaraLocationLimit.camaraLimitY.y)
        {
            if (this.transform.position.y<0)
            {
                this.transform.Translate(new Vector3(0,10,0)*Time.deltaTime,Space.World);
            }
            else
            {
                this.transform.Translate(new Vector3(0,-50,0)*Time.deltaTime,Space.World);
            }
        }
        else if (this.transform.position.z < GameManager.Instance.camaraLocationLimit.camaraLimitZ.x || this.transform.position.z > GameManager.Instance.camaraLocationLimit.camaraLimitZ.y)
        {
            if (this.transform.position.z<-30)
            {
                this.transform.Translate(new Vector3(0,0,50)*Time.deltaTime,Space.World);
            }
            else
            {
                this.transform.Translate(new Vector3(0,0,-50)*Time.deltaTime,Space.World);
            }
        }
    }

    /// <summary>
    /// 摄像机围绕目标操作
    /// </summary>
    private void CameraRotate()
    {
        if (GameManager.Instance.camaraOperation.cameraAutoRotate)
        {
            transform.RotateAround(_target.position, Vector3.up, GameManager.Instance.camaraOperation.cameraRotateSpeed * Time.deltaTime); //摄像机围绕目标旋转
        }
        
        //鼠标
        var mouseX = Input.GetAxis("Mouse X"); //获取鼠标X轴移动
        var mouseY = -Input.GetAxis("Mouse Y"); //获取鼠标Y轴移动

        // //旋转
        // if (Input.GetKey(KeyCode.Mouse0))
        // {
        //     _time = 0;
        //     Rotate(mouseX, mouseY);
        // }

        //移动
        if (EasyTouch.GetTouchCount() <= 1)
        {
            if (Input.GetKey(KeyCode.Mouse1)|| Input.GetKey(KeyCode.Mouse2))
            {
                _time = 0;
                CameraMove(mouseX, mouseY);
            }
        }

    }

    /// <summary>
    /// 摄像机移动
    /// </summary>
    /// <param name="x">X轴移动数据</param>
    /// <param name="y">Y轴移动数据</param>
    private void CameraMove(float x, float y)
    {
        transform.Translate(Vector3.left * (x * GameManager.Instance.camaraOperation.cameraMoveSpeed * Time.deltaTime));
        transform.Translate(Vector3.up * (y * GameManager.Instance.camaraOperation.cameraMoveSpeed * Time.deltaTime));
    }

    /// <summary>
    /// 摄像机旋转
    /// </summary>
    /// <param name="x">X轴移动数据</param>
    /// <param name="y">Y轴移动数据</param>
    private void Rotate(float x, float y)
    {
        // Transform transform1;
        // (transform1 = transform).RotateAround(_target.transform.position, Vector3.up, x * 5); //左右旋转

        Transform transform1;
        transform1 = this.transform;
        transform1.RotateAround(_target.transform.position, Vector3.up, x * 5); //左右旋转
        
        //分拆旋转数值
        float a = transform1.rotation.eulerAngles.x;
        if (a > 180)
        {
            a -= 360.0f;
        }

        //分拆处理上下旋转最大值
        if (y > 0)
        {
            if (a < GameManager.Instance.camaraLocationLimit.camaraAngle.y)
            {
                transform.RotateAround(_target.transform.position, transform.right, y * 5); //上下旋转
            }
        }
        else if (y < GameManager.Instance.camaraLocationLimit.camaraAngle.x)
        {
            if (a > 0)
            {
                transform.RotateAround(_target.transform.position, transform.right, y * 5); //上下旋转
            }
        }
    }

    /// <summary>
    /// //摄像机缩放
    /// </summary>
    private void CameraZoom()
    {
        GameManager.Instance.camaraParameter.cameraDistance = (this.transform.position - _target.transform.position).magnitude;

        if (GameManager.Instance.camaraOperation.cameraCurrentZoom > 0)
        {
            if (GameManager.Instance.camaraParameter.cameraDistance < GameManager.Instance.camaraOperation.cameraMINDistance)
            {
            }
            else
            {
                transform.Translate(Vector3.forward * (GameManager.Instance.camaraOperation.cameraZoomSpeed * GameManager.Instance.camaraOperation.cameraCurrentZoom));
            }
        }

        else if (GameManager.Instance.camaraOperation.cameraCurrentZoom < 0)
        {
            if (GameManager.Instance.camaraParameter.cameraDistance > GameManager.Instance.camaraOperation.cameraMAXDistance)
            {
            }
            else
            {
                transform.Translate(Vector3.forward * (GameManager.Instance.camaraOperation.cameraZoomSpeed * GameManager.Instance.camaraOperation.cameraCurrentZoom));
            }
        }
        GameManager.Instance.camaraOperation.cameraCurrentZoom = Input.GetAxis("Mouse ScrollWheel");

    }
}