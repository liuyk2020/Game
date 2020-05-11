using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class animationByLDoor : MonoBehaviour
{
    private bool DoorState=false;
    private Animation anim;
    private string animName = "AnimationByLeftDoor";
    private void Start()
    {
        anim = GetComponent<Animation>();
    }
    //private void OnMouseDown()
    //{
    //    if (DoorState)
    //    {//播放关门动画  close door Animation
    //        if(anim.isPlaying==false)
    //        anim[animName].time = anim[animName].length; //将播放初始位置调成 1
    //        anim[animName].speed = -1; //重末尾开始播放   0————>0     1————>0
    //    }
    //    else
    //    {//播放开门动画  open door Animation
    //        anim[animName].speed = 1;
    //    }
    //    anim.Play(animName);
    //    DoorState = !DoorState;
    //}


    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (DoorState)
            {//播放关门动画  close door Animation
                if (anim.isPlaying == false)
                    anim[animName].time = anim[animName].length; //将播放初始位置调成 1
                anim[animName].speed = -1; //重末尾开始播放   0————>0     1————>0
            }
            else
            {//播放开门动画  open door Animation
                anim[animName].speed = 1;
            }
            anim.Play(animName);
            DoorState = !DoorState;
        }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        if (DoorState)
    //        {//播放关门动画  close door Animation
    //            if (anim.isPlaying == false)
    //             anim[animName].time = anim[animName].length; //将播放初始位置调成 1
    //            anim[animName].speed = -1; //重末尾开始播放   0————>0     1————>0
    //        }
    //        else
    //        {//播放开门动画  open door Animation
    //            anim[animName].speed = 1;
    //        }
    //        anim.Play(animName);
    //        DoorState = !DoorState;
    //    }
    }
}
