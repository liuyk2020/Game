 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 枪
/// </summary>
/// 
[RequireComponent(typeof(AudioSource))]
public class Gun : MonoBehaviour
{
    Text ammoUi;
    
    /// <summary>
    /// 需要发射的子弹预制件
    /// </summary>
    public GameObject bulletPrefab;
    public GameObject firePoint;
    private GunAnimation anim;
    private MuzzleFlash muzzleFlash;
    /// <summary>
    /// 攻击力
    /// </summary>
    public float atk = 100;

    private AudioSource audioSource;
    /// <summary>
    /// 发射时的子弹音频片段
    /// </summary>
    public AudioClip clipFire;
    public AudioClip clipDryFire;
    public AudioClip clipAmmoUpdate;
    /// <summary>
    /// 开火
    /// </summary>
    /// 
    public void Firing(Vector3 direction)//玩家 枪 发射 ：枪口方向, 敌人发射 ：从枪口位置朝向玩家头部位置
    {



        //如果敌人枪没有动画 不调用准备子弹方法 准备子弹失败
        if (anim != null && Ready() == false)
        {
            audioSource.PlayOneShot(clipDryFire);
            return;
        }
        

        //判断弹夹内是否包含子弹 
        

        
        //播放音频
        audioSource.PlayOneShot(clipFire);
        //如果具有动画,播放动画
        if (anim)anim.action.PlayQueued(anim.fireAnimName);

        //开启火光
        if(muzzleFlash) muzzleFlash.DisplayFlash();
        //创建子弹
        GameObject bulletGo = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.LookRotation(direction));
        //传递信息
        bulletGo.GetComponent<Bullet>().atk = atk;
    }

    //为子类提供重写Start方法的机会
    protected virtual void Start()
    {

        ammoUi = GameObject.Find("ammo").GetComponentInChildren<Text>();
        // print("Gun-Start");
        anim = GetComponent<GunAnimation>();
       muzzleFlash= GetComponentInChildren<MuzzleFlash>();
        audioSource = GetComponent<AudioSource>();
    }


    //准备子弹
    private bool Ready()
    {
        //如果弹夹内没有子弹 或 正在播放更换弹夹动画
        if (currentAmmoBullets <= 0 || anim.action.isPlaying(anim.updateAmmoAnimName))
            return false;
        //减少弹夹内子弹数
        currentAmmoBullets--;

        ammoUi.text = string.Format("AMMO  {0}/{1}", currentAmmoBullets, remainBullets);
        //如果弹夹内没有子弹了

        if (currentAmmoBullets == 0)
            anim.action.PlayQueued(anim.lackBulleAnimName);
        return true;
        //弹夹内是否有子弹

        //如果缺少子弹 播放缺少子弹动画

       
    }


    /// <summary>
    /// 弹夹容量
    /// </summary>
    public int  AmmoCapacity=40;
    /// <summary>
    /// 当前弹夹内子弹数
    /// </summary>
    public int currentAmmoBullets=40;
    /// <summary>
    /// 剩余子弹数
    /// </summary>
    public int remainBullets;

    /// <summary>
    /// 更换弹夹
    /// </summary>
    public void UpdateAmmo()
    {
        //如果没有剩余子弹
        if (remainBullets <= 0||currentAmmoBullets==AmmoCapacity) return;
        //判断剩余弹夹数量
        currentAmmoBullets = remainBullets >= AmmoCapacity ? AmmoCapacity : remainBullets;

        remainBullets -= currentAmmoBullets;
        anim.action.Play(anim.updateAmmoAnimName);
        audioSource.PlayOneShot(clipAmmoUpdate);
        ammoUi.text = string.Format("AMMO  {0}/{1}", currentAmmoBullets, remainBullets);

    }

    private void Update()
    {
      
        
    }
}
