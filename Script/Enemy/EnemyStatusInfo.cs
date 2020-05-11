using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 敌人信息/受伤/死亡
/// </summary>
public class EnemyStatusInfo : MonoBehaviour
{/// <summary>
/// 血量最大值
/// </summary>
    public float EnemyHpMax = 1000;
    /// <summary>
    /// 当前血量
    /// </summary>
    public float EnemyHP = 1000;
    /// <summary>
    /// 死亡延迟销毁时间
    /// </summary>
    public float DeathDelay = 3;

   
   
    public EnemySpawn spawn;

    
    
 


    /// <summary>
    /// 受伤
    /// </summary>
    /// <param name="amount">需要扣除的血量</param>
    public void EnemyBeAttacked(float amount)
    {
        if (EnemyHP <= 0) return;
        
        EnemyHP -= amount;

       


        if (EnemyHP <= 0)
        {
          EnemyDeath();
        }
        
           
       
    }
    public void EnemyDeath()
    {
       
        GetComponent<EnemyAI>().enabled = false;
        var anim = GetComponent<EnemyAnimation>();
        anim.action.Play(anim.deathAnimName);

       
        Destroy(gameObject, DeathDelay);

        //播放死亡动画

        //将路线还原
        GetComponent<EnemyMotor>().line.isUsable = true;
        //产生下一个敌人
        spawn.GenerateEnemy();

        



    }


}
