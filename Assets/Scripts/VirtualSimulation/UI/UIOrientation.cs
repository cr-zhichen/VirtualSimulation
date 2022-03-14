/*
 * 使UI始终朝向相机
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UIOrientation : MonoBehaviour
{
    private Transform _camera;
    private bool _isCameraNull;

    private void Start()
    {
        _camera = GameManager.Instance.camaraParameter.cameraGameObject.transform;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _camera.position);
    }
}
