using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人动画类，定义需要播放的动画片段名称
/// </summary>
public class EnemyAnimation : MonoBehaviour
{
    public string runAnimName;


    public string attackAnimName ;
    /// <summary>
    /// 闲置动画名称
    /// </summary>

    public string idleAnimName ;


    public string deathAnimName ;

    public AnimationAction action;

    public void Awake()
    {
        //action=new AnimationAction(?)
        action =  new AnimationAction(GetComponentInChildren<Animation>());
        
    }
    



}
