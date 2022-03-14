/*****************************************

    文件：CamaraPos_UI.cs
    作者：程瑞
    邮箱：296529530@qq.com
    功能：视角固定为指定序号位置

******************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamaraPos_UI : MonoBehaviour
{
    //相机位置编号
    public int PositionSerialNumber;

    private void Start()
    {
        GameManager.Instance.camaraTransform[PositionSerialNumber].wordClickUI = this.gameObject;
        GetComponent<Button>().onClick.AddListener(() =>
        {
            GameManager.Instance.camaraTransform[PositionSerialNumber].wordClickUI = this.gameObject;
            EventCenter.Broadcast<Vector3, Quaternion>(
                ENventType.CameraMove,
                GameManager.Instance.camaraTransform[PositionSerialNumber].camaraPos,
                GameManager.Instance.camaraTransform[PositionSerialNumber].camaraRot);
        });
    }
}
