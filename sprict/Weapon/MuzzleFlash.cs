using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 附加到枪口，用于实现枪口特效。
/// </summary>
public class MuzzleFlash : MonoBehaviour
{
    /// <summary>
    /// 特效
    /// </summary>
    public GameObject flashGo;

    //计时器
    private float hideTimer;
    /// <summary>
    /// 显示时间
    /// </summary>
    public float displayTime = 0.3f;

    /// <summary>
    /// 提供显示火光的功能
    /// </summary>
    public void DisplayFlash()
    {
        print("开启效果"+gameObject.name);
        flashGo.SetActive(true);
        //隔段时间禁用物体
        hideTimer = Time.time + displayTime;
    }

    private void Update()
    {
        //如果火光启用  且 到了隐藏时间
        if (flashGo.activeInHierarchy==true && Time.time >= hideTimer)
        {
            flashGo.SetActive(false);
        }
        //******************测试***************
        //if (Input.GetMouseButtonDown(0))
        //{
        //    DisplayFlash();
        //}
    }


}