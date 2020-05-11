using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

/// <summary>
/// 触发对话
/// </summary>

public class Chat : MonoBehaviour
{

    
    public string ChatName;
    private bool canchat = false;
    private int count;


    private void OnTriggerEnter(Collider other)
    {
        canchat = true;
    }
    private void OnTriggerExit(Collider other)
    {
        canchat = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            Say();
            
        }

        if (count == 4)
        {
            Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            if (flowchart.HasBlock("over"))
            {
                flowchart.ExecuteBlock("over");

            }
        }


    }

    void Say()
    {
        if (canchat)
        {
            Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            if (flowchart.HasBlock(ChatName))
            {
                flowchart.ExecuteBlock(ChatName);
                count++;
            }

        }
        
    }
}
