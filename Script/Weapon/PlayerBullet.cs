using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家子弹
/// </summary>
public class PlayerBullet : Bullet
{
    //根据敌人部位减血
    //希望到达物体上再减血，需要使用委托
    private void Start()
    {
        //击中部位的名称：
        //base.hit.collider.name
       
        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            float atk = CalculateAttackForce();
            print(atk);
            hit.collider.GetComponentInParent<EnemyStatusInfo>().EnemyBeAttacked(atk);
            //hit.collider.GetComponentInChildren<EnemyHpUiCountDown>().EnemyBeAttackedByUi(atk);
           // if (Vector3.Distance(gameObject.transform.position, hit.collider.transform.position) < 5)
                hit.collider.transform.Find("Canvas").GetComponentInChildren<EnemyHpUiCountDown>().EnemyBeAttackedByUi(atk);

        }
       
    }
    private float CalculateAttackForce()
    {

        //【建议使用配置文件替换】
        //根据受击物体部位名称
        switch (hit.collider.name)
        {
            case "PA_Warrior":
                return atk * 2;
            default:
                return atk;
            
        }
    }

    
}
