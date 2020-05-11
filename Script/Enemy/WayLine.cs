using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 路线类
/// </summary>
public class WayLine 
{/// <summary>
/// 当前路线所有路点坐标
/// </summary>
   public Vector3[] WayPoints { get; set; }
   public bool isUsable { get; set; }

    //构造函数。。。
    public WayLine(int wayPointCount)
    {
        WayPoints = new Vector3[wayPointCount];
        isUsable = true;
    }
}
