using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ak47的开关
/// </summary>
public class GunSwitch : MonoBehaviour
{
    public GameObject ak47;
    public GameObject gun;
   
    private void Update()
    {
        if (Vector3.Distance(transform.position, gun.transform.position) > 100)
        {

            ak47.SetActive(true);
        }
    }
}
