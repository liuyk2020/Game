using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人马达：做移动，转向，向下一个目标走
/// </summary>
public class EnemyMotor : MonoBehaviour
{
    
    public float moveSpeed=1;
    public WayLine line;
    private int count;
    GameObject player;
    private void Start()
    {
        player = GameObject.Find("FPSController");
    }


    /// <summary>
    /// 载体向前走
    /// </summary>
    public void EnemyMoveForward()
    {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    }
    /// <summary>
    /// 注视旋转
    /// </summary>
    /// <param name="targetPoint">注视的目标点</param>
    public void LookRotation(Vector3 targetPoint)
    {//当前物体注视这目标旋转
     //transform.LookAt(targetPoint);
     //Quaternion dir = Quaternion.LookRotation(targetPoint - transform.position);
     //transform.rotation = Quaternion.Lerp(transform.rotation, dir, 0.1f);
     //if (Quaternion.Angle(dir, transform.rotation) < 10)
     //    transform.rotation = dir;

        Quaternion dir =
            Quaternion.Lerp
            (
                transform.rotation,
                Quaternion.LookRotation(targetPoint - transform.position),
                0.1f
             );
        if (Quaternion.Angle(dir, transform.rotation) < 1)
            transform.rotation = dir;
        //得到旋转角度
        Vector3 euler = dir.eulerAngles;

        //冻结y轴以外的轴
        transform.eulerAngles = new Vector3(0, euler.y, 0);


    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="wayLine"></param>
    /// <returns></returns>
    /// 
    //private void DetectionPlayer()
    //{
    //    Quaternion dir = Quaternion.LookRotation(player.transform.position - transform.position);

    //    transform.rotation = Quaternion.Lerp(transform.rotation, dir, 0.5f);
    //    //永远不能到达
    //    if (Quaternion.Angle(dir, transform.rotation) < 10)
    //    {
    //        transform.rotation = dir;
    //    }
    //    transform.Translate(0, 0, Time.deltaTime * moveSpeed);
    //}


    public bool PathFind()
    {

        //if (Vector3.Distance(player.transform.position, transform.position) < 1)
        //{
        //    return false;
        //}
        //else
        //{
        //    return true;
        //}

        //如果 路线不为NUll  或者 点达到上限    就退出寻路
        if (line == null || count >= line.WayPoints.Length) return false;

        //如过走到头 就返回原点 再走一次
        //if (count == line.WayPoints.Length) count = 0;

        //转向目标点
        LookRotation(line.WayPoints[count]);

        //向前走
        EnemyMoveForward();

        //设定阈值
        if (Vector3.Distance(transform.position, line.WayPoints[count]) < 2)
            count++;

        return true;


    }


  
}
