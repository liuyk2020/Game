using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 控制门开关
/// </summary>
public class animationControllerByDoor : MonoBehaviour
{
    private bool DoorState = false;
    private Animation left;
    private Animation right;
    private string RightDoor= "AnimationByRightDoor";
    private string LeftDoor= "AnimationByLeftDoor";
    bool enter;

    
    private void Start()
    {
        left = GameObject.Find("leftDoor").GetComponent<Animation>();
        right= GameObject.Find("rightDoor").GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {

        enter = true;
    }
    private void OnTriggerExit(Collider other)
    {
        enter = false;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q)&&enter)
        {
            if (DoorState)
            {//播放关门动画  close door Animation
                if (left.isPlaying == false && right.isPlaying == false)
                {
                    right[RightDoor].time = right[RightDoor].length; //将播放初始位置调成 1
                    left[LeftDoor].time = left[LeftDoor].length;
                }


                right[RightDoor].speed = -1; //重末尾开始播放   0————>0     1————>0
                left[LeftDoor].speed = -1;
            }
            else
            {//播放开门动画  open door Animation
                right[RightDoor].speed = 1;
                left[LeftDoor].speed = 1;
            }
            left.Play(LeftDoor);
            right.Play(RightDoor);
            DoorState = !DoorState;
        }

    }
}
