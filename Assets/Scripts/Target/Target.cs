/*
 * 广播展示物体位置 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void Start()
    {
        Instantiate(GameManager.Instance.camaraTarget.prefab,this.transform);
        GameManager.Instance.camaraTarget.target = this.transform;
    }
    
}
