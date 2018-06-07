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
            instance = new ItemManager();
        }
        else
        {
            Destroy(this);
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
        ItemSetting();
    }
    private void ItemSetting()
    {
        var ids = ItemTable.GetIds();
        ItemTable.GetData(ids[0]).ItemAction += BigItem;
        ItemTable.GetData(ids[1]).ItemAction += FastItem;
        ItemTable.GetData(ids[2]).ItemAction += SlowItem;
    }

    //  public bool isUsingItem = false;

    public void BigItem(int runTime)
    {
        // 거대화 아이템 효과
        // print("거대화 아이템 발동");
        PlayerControl.Big(runTime);
        CancelInvoke("ResetTime");
    }

    public void SlowItem(int runTime)
    {
        CancelInvoke("ResetTime");
        // 슬로우 아이템 효과
        Time.timeScale = 0.5f;
        InvertEffect.OnSlowEffect(runTime);
        Invoke("ResetTime", runTime);
    }

    public void FastItem(int runTime)
    {
        CancelInvoke("ResetTime");
        Time.timeScale = 2;
        InvertEffect.OnFastEffect(runTime);
        Invoke("ResetTime", runTime);
    }

    private void ResetTime()
    {
        Time.timeScale = 1;
    }
}
