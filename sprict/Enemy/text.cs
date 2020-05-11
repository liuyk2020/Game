using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class text : MonoBehaviour
{
    private Animation anim;
    private void Start()
    {
         anim = GetComponent<Animation>();
        
    }
    private void Update()
    {
        anim.Play("WarriorForward");
    }
}
