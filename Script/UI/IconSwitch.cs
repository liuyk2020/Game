using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 图标开关
/// </summary>

public class IconSwitch : MonoBehaviour
{
    public GameObject item;
    
    GameObject player;
    private void Start()
    {
        
        player = GameObject.Find("FPSController");
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position,item.transform.position)>100)
        {
            GetComponent<Image>().enabled = true;
           
        }
    }
}
