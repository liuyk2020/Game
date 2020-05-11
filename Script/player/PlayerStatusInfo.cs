using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 玩家状态信息类
/// </summary>
public class PlayerStatusInfo : MonoBehaviour
{
    //提供当前类的对象引用 0105
    public static PlayerStatusInfo instance { get; private set; }
    /// <summary>
    /// 玩家头部位置变换组件
    /// </summary>
    public Transform headTF;


    Slider UiHP;
    private void Awake()
    {
        UiHP = GameObject.Find("Slider").GetComponent<Slider>();
         instance = this;
    }
    public float Hp = 1000;
    public float maxHp = 1000;
    
    public void Damage(float amount)
    {
        Hp -= amount;
        //闪现红屏
        Debug.Log("Hp--");
        if (Hp <= 0)
        {
            UiHP.transform.Find("Fill Area").GetComponentInChildren<Image>().color = Color.black;
            Death();
        }

        //ui 血条减少
        UiHP.value = Hp;
    }

    public void Death()
    {
        //游戏结束
        Debug.Log("GameOver");
    }
}
