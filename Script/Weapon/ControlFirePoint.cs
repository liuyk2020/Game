using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class ControlFirePoint : MonoBehaviour
{
    GameObject FireLight;
    /// <summary>
    /// 结束射击后火焰延迟的时间
    /// </summary>
    float OverTime ;
    public float displayFireTime=0.3f;
    private float totalTime;

    private void Start()
    {
        FireLight = transform.Find("WFX_MF 4P RIFLE1").gameObject;
        FireLight.SetActive(false);

    }
    public void display()
    {
        FireLight.SetActive(true);
        totalTime = Time.time + displayFireTime;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            display();
        }
       if(FireLight.activeInHierarchy&&Time.time>totalTime)
            FireLight.SetActive(false);


    }


}
