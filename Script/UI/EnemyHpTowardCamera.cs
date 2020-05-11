using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class EnemyHpTowardCamera : MonoBehaviour
{
   
    
    private void Update()
    {
        GetComponent<RectTransform>().LookAt(PlayerStatusInfo.instance.headTF.position);
        
    }
}
