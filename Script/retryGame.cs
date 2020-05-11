using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class retryGame : MonoBehaviour
{

    public GameObject player;
    public GameObject OnPanel, OnUnPanel;
    private bool pauseGame = false;
    private FirstPersonController fpc;
    void Start()
    {
        fpc = player.GetComponent<FirstPersonController>();
        OnUnPause();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame = !pauseGame;

            if (pauseGame == true)
            {
                OnPause();
            }
            else
            {
                OnUnPause();
            }
        }
    }

    public void OnPause()
    {
        OnPanel.SetActive(true);        // PanelMenuをtrueにする
        OnUnPanel.SetActive(false);     // PanelEscをfalseにする
        Time.timeScale = 0;
        pauseGame = true;
        FirstPersonController fpc = player.GetComponent<FirstPersonController>();
        //FirstPersonController fpc = GetComponent<FirstPersonController>();
        fpc.enabled = false;

        Cursor.lockState = CursorLockMode.None;     // 標準モード
        Cursor.visible = true;    // カーソル表示
    }

    public void OnUnPause()
    {
        Debug.Log("unpause");

        
        Cursor.visible = false;     // カーソル非表示
        Cursor.lockState = CursorLockMode.Locked;   // 中央にロック
       //FirstPersonController fpc = player.GetComponent<FirstPersonController>();
        fpc.enabled = true;
        pauseGame = false;
        Time.timeScale = 1;
        
        OnUnPanel.SetActive(true);      // PanelEscをtrueにする
        OnPanel.SetActive(false);       // PanelMenuをfalseにする





    }

    public void OnRetry()
    {
        SceneManager.LoadScene("11.21room");
    }

    public void OnResume()
    {
        OnUnPause();
    }
}