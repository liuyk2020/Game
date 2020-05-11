using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 枪动画
/// </summary>
public class GunAnimation : MonoBehaviour
{
    //开枪动画
    public string fireAnimName = "Ak47_fire";
    //更换弹夹动画
    public string updateAmmoAnimName = "Ak47_UpdateAmmo";
    //缺少子弹动画
    public string lackBulleAnimName = "Ak47_lackBullets";

    public AnimationAction action;

    private void Awake()
    {
        action =new AnimationAction(GetComponentInChildren<Animation>());
    }
}
