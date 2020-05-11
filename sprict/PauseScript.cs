using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour
{

    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject pauseUIPrefab;
    //　ポーズUIのインスタンス
    private GameObject pauseUIInstance;

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape ))
        {
            if (pauseUIInstance == null)
            {
               // pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
                Time.timeScale = 0f;
            }
            else
            {
                Destroy(pauseUIInstance);
                Time.timeScale = 1f;
            }
        }
    }
}