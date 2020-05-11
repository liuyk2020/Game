using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人生成器
/// </summary>
public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyType;
    WayLine[] lines;
    public float maxTimeDelay = 100;
    //需要创建敌人最大数目
    public int maxCount = 5;
    /// <summary>
    /// 开始创建的敌人数目
    /// </summary>
    public int startCount = 2;
    /// <summary>
    /// 已经创建的敌人数量
    /// </summary>
    private int spawnedCount;
    private float EnemySpawnTime;
    //选择一条可以使用的路线
    private WayLine[] SelectUsableWayLine()
    {
        List<WayLine> result = new List<WayLine>(lines.Length);
        
        foreach (var item in lines)
        {
           if(item.isUsable) result.Add(item);//子物体自带wayline属性。
        }
        return result.ToArray();
    }
    public void GenerateEnemy()
    {
        spawnedCount++;
        if (spawnedCount > maxCount)
        {
            return;//退出方法。
        }
        //延迟产生一个敌人
        Invoke("CreateEnemy", Random.Range(1, maxTimeDelay)); ;
       



        //延迟时间随机 
    }

    private void CreateEnemy()
    {
        WayLine[] result = SelectUsableWayLine();
        WayLine line = result[Random.Range(0, result.Length)];

        //创建敌人
        //Object.Instantiate(敌人预制件，第一个点的位置，旋转角度)
        int count = Random.Range(0, enemyType.Length);
        GameObject go = Instantiate(enemyType[count], line.WayPoints[0], Quaternion.identity);
        //设置参数
        EnemyMotor motor = go.GetComponent<EnemyMotor>();
        motor.line = line;
        line.isUsable = false;//不可使用
        //********************************

        //传递生成器引用给EnemyStatusInfo
        go.GetComponent<EnemyStatusInfo>().spawn = this;

   
    }

    private void Start()
    {
        CalculateWayLine();
        for (int i = 0; i < startCount; i++)
        {
            CreateEnemy();
        }
    }
    
    private void CalculateWayLine()
    {
        lines = new WayLine[transform.childCount];
        for (int i = 0; i < lines.Length; i++)
        {//每一条路线
            //路线变换组件的引用
            Transform wayLineTF = transform.GetChild(i);
            //创建路线对象
            lines[i] = new WayLine(wayLineTF.childCount);
           
            //创建路点对象
            
            for (int pointIndex = 0; pointIndex < wayLineTF.childCount; pointIndex++)
            {
                lines[i].WayPoints[pointIndex] = wayLineTF.GetChild(pointIndex).position;

            }
        }
    }


   
}
