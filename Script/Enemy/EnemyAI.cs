using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人AI，控制敌人在相应位置做什么
/// </summary>
/// 
[RequireComponent(typeof(EnemyMotor))]
[RequireComponent(typeof(EnemyAnimation))]
[RequireComponent(typeof(EnemyStatusInfo))]

public class EnemyAI : MonoBehaviour
{

   
    public enum State// 枚举  类型
    {
        Attack,
        PathFind,
        idle
    }

    private GameObject player;
    private EnemyAnimation anim;
    private EnemyMotor motor;
    private Gun gun;
    EnemyStatusInfo info;
    private float atkTime;
    /// <summary>
    /// 攻击间隔
    /// </summary>
    public float atkInterval = 3;
    /// <summary>
    /// 当前敌人状态
    /// </summary>
    private State currentState=State.PathFind;
    public float  delay=0.3f;

    private void Start()
    {
        player = GameObject.Find("FPSController");
        info = GetComponent<EnemyStatusInfo>();
        anim = GetComponent<EnemyAnimation>();
        motor = GetComponent<EnemyMotor>();
        gun = GetComponentInChildren<Gun>();
    }
    private void Update()
    {
        //判断
        switch (currentState)
        {
            case State.Attack:
                attack();
                //Debug.DrawLine(gun.firePoint.transform.position, PlayerStatusInfo.instance.headTF.position,Color.red);
                break;
            case State.PathFind:
                pathFind();
                break;
            case State.idle:
                idle();
                break;

        }

        if (Vector3.Distance(transform.position, player.transform.position) < 10 || info.EnemyHP < info.EnemyHpMax)
        {

            print("反击");
            currentState = State.Attack;
        }
    }

    private void pathFind()
    {
        //播放寻路动画
        
        anim.action.Play(anim.runAnimName);
        //寻路
        motor.PathFind();
        //如果寻路结束，将状态调整为闲置
        if (motor.PathFind() == false)
        {
            currentState = State.idle;
        }
        else
        {
            currentState = State.PathFind;
        }

       
     
    }

    private void attack()
    {

        //转向
        motor.LookRotation(PlayerStatusInfo.instance.headTF.position);
        //如果不在播放攻击动画时，播放攻击动画
        if (!anim.action.isPlaying(anim.attackAnimName))
            anim.action.Play(anim.attackAnimName);
        //播放攻击动画
        if (atkTime <= Time.time)
        {
            //anim.action.Play(anim.attackAnimName);
            //if(gameObject.name!= "PA_Warrior")
            
                Invoke("Shoot", delay);
            
            
            atkTime = Time.time + atkInterval;
        }

      
        
        
    }
    private void idle()
    {
        anim.action.Play(anim.idleAnimName);
    }

    private void Shoot()
    {
        //发起攻击
       
           if(gun) gun.Firing(PlayerStatusInfo.instance.headTF.position - gun.firePoint.transform.position);

        

    }

}
