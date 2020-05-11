using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
/// <summary>
/// 关闭 UI文字
/// </summary>
public class CloseUITitle : MonoBehaviour
{

    private GameObject player;
    //public GameObject OnPenPanel, OnPhonePanel, OnresumePanel,OnUnPanel;
    public GameObject OnPanel;
    
    void Start()
    {
        player = GameObject.Find("FPSController");

        //游戏开始关闭标题
        OnUnPause();
        
    }


   
   

    private void OnTriggerEnter(Collider other)
    {
        //玩家走近时开启
        OnPanel.SetActive(true);
       

        //Debug.Log(other.gameObject);

        //if (other.gameObject.name == "Pen_blue") OnPenPanel.SetActive(true);
        //else OnPenPanel.SetActive(false);

        //if (other.gameObject.name == "smartphone") OnPhonePanel.SetActive(true);
        //else OnPhonePanel.SetActive(false);

        //if (other.gameObject.name == "PAGE") OnresumePanel.SetActive(true); //resume
        //else OnresumePanel.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {

        //离开时关闭
        OnPanel.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        //没看时关闭
        if (OnPanel == false) return;
        else OnPanel.SetActive(false);



    }


    public void OnUnPause()
    {
        //Debug.Log("unpause");

        OnPanel.SetActive(false);

        //OnPenPanel.SetActive(false);
        //OnPhonePanel.SetActive(false);
        // PanelMenuをfalseにする

    }
}


