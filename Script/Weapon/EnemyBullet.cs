using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人子弹
/// </summary>
public class EnemyBullet : Bullet
{
    private void OnTriggerEnter(Collider other)
    {

       
        //如果与玩家接触
        if (other.tag == "Player")
        {
            //玩家减血
            PlayerStatusInfo.instance.Damage(atk);
            Destroy(gameObject);
        }
        
    }
}

