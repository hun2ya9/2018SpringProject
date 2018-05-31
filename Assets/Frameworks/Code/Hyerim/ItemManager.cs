using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance = new ItemManager();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

  //  public bool isUsingItem = false;
    
    public void BigItem(int runTime)
    {
        // 거대화 아이템 효과
        // print("거대화 아이템 발동");
    }

    public void SlowItem(int runTime)
    {
        // 슬로우 아이템 효과
        Time.timeScale = 0.5f;
        InvertEffect.OnSlowEffect(runTime);
        Invoke("ResetTime", runTime);
    }

    public void FastItem(int runTime)
    {
        Time.timeScale = 2f;
        InvertEffect.OnFastEffect(runTime);
        Invoke("ResetTime", runTime);
    }
    private void ResetTime()
    {
        Time.timeScale = 1;
    }
}
