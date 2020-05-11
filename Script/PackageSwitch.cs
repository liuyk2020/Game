using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 口袋开关
/// </summary>
public class PackageSwitch : MonoBehaviour
{
    GameObject itemParent;

    //private bool Active = false;
    private void Awake()
    {
       
        //itemParent.SetActive(false);   放在这里 脚本为启用就关闭 PickUp的PenIcon取不到引用。
    }
    void Start()
    {

        itemParent = GameObject.Find("ItemParent");
        itemParent.SetActive(false);

    }
   
       
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("clicked");
            if (itemParent.activeSelf)
            {
                itemParent.SetActive(false);
            }

            else
            {
                itemParent.SetActive(true);
            }
        }





    }

}

