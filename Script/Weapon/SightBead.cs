using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 准星
/// </summary>
public class SightBead : MonoBehaviour
{

    public Camera cameraui;
    public Transform firePos;
    RaycastHit hit;
    public LayerMask mask;
    public RectTransform ui;
    private void Update()
    {
       if( Physics.Raycast(firePos.position,firePos.forward,out hit ,100,mask))
        {
            ui.gameObject.SetActive(true);
            Vector3 gunUI = cameraui.WorldToScreenPoint(hit.point);
            ui.position = gunUI;

        }
        else
        {
            ui.gameObject.SetActive(false);
        }
        Debug.DrawLine(firePos.position, hit.point, Color.red);
    }
}
