using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 动画行为类，提供播放
/// </summary>
public class AnimationAction //: MonoBehaviour
{
    //附加在敌人模型上的动画组件引用
    private Animation anim;
    /// <summary>
    /// 创建动画行为类
    /// </summary>
    /// <param name="anim">附加在敌人模型上的动画组件引用</param>

    public AnimationAction(Animation anim)
    {
        this.anim = anim;

    }
    public void Play(string animName)
    {
        
        anim.CrossFade(animName);
    }

    public void PlayQueued(string animName)
    {
        anim.PlayQueued(animName);
    }
    /// <summary>
    /// 判断指定动画是否在播放。
    /// </summary>
    /// <param name="animName">动画名称</param>
    /// <returns></returns>
    public bool isPlaying(string animName)
    {
        return anim.IsPlaying(animName);
    }

}
