using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 单发枪,附加到物体中
/// </summary>
public class SingleGun : Gun
{
    //覆盖父类的Start方法
    //private void Start()
    //{
    //    print("SingleGun+Start");
    //}

    

    protected override void Start()
    {
        base.Start();//调用父类的Start
        print("SingleGun+Start");
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Firing(firePoint.transform.forward);

        }
        if (Input.GetMouseButtonDown(1))
        {
            UpdateAmmo();

        }
    }
}
