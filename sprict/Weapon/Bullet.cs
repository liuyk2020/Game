using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 子弹，定义子弹共有行为
/// </summary>
public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public float atk;
    /// <summary>
    /// 攻击距离
    /// </summary>
    public float attackDistance = 400;
    /// <summary>
    /// 射线检测层
    /// </summary>
    public LayerMask mask;
    protected RaycastHit hit;
    private Vector3 targetPos;
    /// <summary>
    /// 子弹移动速度
    /// </summary>
     public float moveSpeed=200;

    private void Awake()
    {
        CalculateTargetPoint();
    }

    //计算目标点
    private void CalculateTargetPoint()
    {
        //从枪口位子，枪口方向，受击目标信息，攻击最大距离，射线检测层
      if( Physics.Raycast(transform.position, transform.forward, out hit, attackDistance, mask))
        {
            targetPos = hit.point;
        }
        else
        {
            targetPos = transform.position + transform.forward * attackDistance;
        }
    }

    private void Update()
    {
        Movemnet();
        if ((transform.position - targetPos).sqrMagnitude < 0.1f)
        {
            Destroy(gameObject);
            GennerateContactEffect();
        }
    }

    //移动
    private void Movemnet()
    {
        transform.position=Vector3.MoveTowards(transform.position,targetPos,moveSpeed*Time.deltaTime);
    }

    //到达目标点：销毁，创建相关特效



    //创建相关特效
    //根据目标点物体的标签hit.collider.tag
    //弹痕 要与攻击面平行

    private void GennerateContactEffect()
    {
        if (hit.collider == null) return;

        //switch (hit.collider.tag)
        //{
        //    case "":
        //        break


        //}
        //特效名称规则：存放路径+接触物体标签

        //通过代码读取资源
        //资源必须放到Resources目录下
        //GameObject prefabGO = Resources.Load<GameObject>("目录文件夹名称/资源对象");

        //[建议使用对象池代替]
        //根据标签加载资源
        GameObject prefabGO = Resources.Load<GameObject>("ContactEffects/Effects" + hit.collider.tag);
        //创建资源
        if (prefabGO)
            Instantiate(prefabGO, targetPos+hit.normal*0.02f, Quaternion.LookRotation(hit.normal));
        //Instantiate(prefabGO)
    }
     
}
