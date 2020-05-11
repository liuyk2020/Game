using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 血量
/// </summary>
public class DisplayHP : MonoBehaviour
{
    Slider HP;
    PlayerStatusInfo player;
    private void Start()
    {
        player = GameObject.Find("FPSController").GetComponent<PlayerStatusInfo>();
        HP = GetComponent<Slider>();
        
    }

    private void Update()
    {
       
        HP.value = PlayerStatusInfo.instance.Hp;
    }


}
