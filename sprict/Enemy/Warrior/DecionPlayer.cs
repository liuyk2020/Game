using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 向主角方向移动
/// </summary>
public class DecionPlayer : MonoBehaviour
{

  



    EnemyAnimation anim;
    GameObject player;
    //EnemyAI ai;
    public float moveSpeed=1;

    EnemyStatusInfo info;
    bool AiSwtich=true;
    bool deathSwicth;
    /// <summary>
    /// 追踪玩家开关
    /// </summary>
    private bool det=false;

    
    private void Start()
    {
         player = GameObject.Find("FPSController");
        anim = GetComponent<EnemyAnimation>();
        info = GetComponent<EnemyStatusInfo>();
        ///ai = GetComponent<EnemyAI>();
        
    }

    private void Update()
    {
        //判断距离
        dictance();


        //当距离小且血量大于0时启动
        //if (det && info.EnemyHP > 0)
        //{
        //    DetectPlayer();
        //}

        //受伤时启动
      



        if ((det && info.EnemyHP > 0) || (info.EnemyHpMax > info.EnemyHP && info.EnemyHP > 0))
        {
            DetectPlayer();
        }

        //血量为0时 调用死亡方法
        if (info.EnemyHP <= 0 && AiSwtich == false)
        {
            deathSwicth = true;
        }


        //if(info.EnemyHP <= 0&&AiSwtich==false)
        //{
        //    deathSwicth = true;
        //}
    }

   private void dictance()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 10)
        {
            det = true;
        }
    }

    private void DetectPlayer()
    {

        AiSwtich =GetComponent<EnemyAI>().enabled = false;
        //Quaternion dir = Quaternion.LookRotation(player.transform.position - transform.position);

        //transform.rotation = Quaternion.Lerp(transform.rotation, dir, 0.5f);
        ////永远不能到达
        //if (Quaternion.Angle(dir, transform.rotation) < 10)
        //{
        //    transform.rotation = dir;
        //}

        Quaternion dir =
           Quaternion.Lerp
           (
               transform.rotation,
               Quaternion.LookRotation(player.transform.position - transform.position),
               0.1f
            );
        if (Quaternion.Angle(dir, transform.rotation) < 1)
            transform.rotation = dir;
        //得到旋转角度
        Vector3 euler = dir.eulerAngles;

        //冻结y轴以外的轴
        transform.eulerAngles = new Vector3(0, euler.y, 0);
        anim.action.Play(anim.runAnimName);
        transform.Translate(0, 0, Time.deltaTime * moveSpeed);

        
    }

    private void OpenDeath()
    {
        if (deathSwicth)
        {
            info.EnemyDeath();
        }
    }


    private void OnTriggerEnter(Collider other)
    {


        //如果与玩家接触
        if (other.tag == "Player")
        {

            print("受到撞击");
            PlayerStatusInfo.instance.Damage(100);
            
        }
        
           
    }
}
