/*
 * 控制地面Shader 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{    
    private float _f;

    private static readonly int Speed = Shader.PropertyToID("Speed");

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().materials[0].SetFloat(Speed,GameManager.Instance.groundShader.groundSpeed);
        GameManager.Instance.groundShader.groundGameObject = this.gameObject;
        _f = GameManager.Instance.groundShader.groundSpeed;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(_f - GameManager.Instance.groundShader.groundSpeed) > 0.0001)
        {
            GetComponent<MeshRenderer>().materials[0].SetFloat(Speed,GameManager.Instance.groundShader.groundSpeed);
            _f = GameManager.Instance.groundShader.groundSpeed;
        }
    }
}
