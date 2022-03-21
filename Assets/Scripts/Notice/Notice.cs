/*****************************************

    文件：Notice.cs
    日期：2022/3/21 14:50:50
    功能：显示通知

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notice : MonoBehaviour
{
    public static Notice Instance { get; private set; }

    public Canvas noticeCanvas;//通知面板
    public GameObject notificationObject;//通知

    public Canvas _noticeCanvas;

    public List<GameObject> _notificationObjectList;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        _noticeCanvas = Instantiate(noticeCanvas,this.transform);

    }

    /// <summary>
    /// 显示通知
    /// </summary>
    /// <param name="text">需要显示的文字</param>
    /// <param name="color">显示颜色(默认为白色)</param>
    /// <param name="whetherToShutDownAutomatical">是否自动消失</param>
    /// <param name="showTime">显示时间（默认为3s）</param>
    /// <returns>通知物体</returns>
    public GameObject AccordingToNotice(string text,Color? color,bool whetherToShutDownAutomatical,float? showTime)
    {

        GameObject g = Instantiate(notificationObject, _noticeCanvas.transform);

        color = new Color(color?.r ?? 1.0f, color?.g ?? 1.0f, color?.b ?? 1.0f, 0.5f);

        g.transform.GetChild(0).GetComponent<Image>().color = color?? new Color(1.0f,1.0f,1.0f,0.5f);
        g.transform.GetChild(1).GetComponent<Text>().text = text;
        
        _notificationObjectList.Add(g);

        if (whetherToShutDownAutomatical==true)
        {
            StartCoroutine(DelayToDelete(showTime ?? 3.0f, g));
        }

        return g;
    }

    /// <summary>
    /// 延迟删除
    /// </summary>
    /// <param name="f">延迟时间</param>
    /// <param name="g">需要删除的物体</param>
    /// <returns></returns>
    IEnumerator DelayToDelete(float f, GameObject g)
    {
        yield return new WaitForSeconds(f);
        
        CloseToInform(g);

    }

    /// <summary>
    /// 关闭通知
    /// </summary>
    /// <param name="g">需要被关闭的通知</param>
    public void CloseToInform(GameObject g)
    {
        foreach (var _g in _notificationObjectList)
        {
            if (g==_g)
            {
                
                _g.GetComponent<Animator>().SetTrigger("Close");

                Destroy(_g,1.0f);
                _notificationObjectList.Remove(_g);
                return;
            }
        }
    }
    
}
