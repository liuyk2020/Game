using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 敌人血量Ui减少
/// </summary>
public class EnemyHpUiCountDown : MonoBehaviour
{
    Slider EnemyHpUi;
    private void Start()
    {
        EnemyHpUi = GetComponentInChildren<Slider>();
        GetComponent<Canvas>().enabled = false;
    }

  


    public void EnemyBeAttackedByUi(float amount)
    {

        EnemyHpUi.value -= amount;

        GetComponent<Canvas>().enabled = true;

        if (EnemyHpUi.value <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
