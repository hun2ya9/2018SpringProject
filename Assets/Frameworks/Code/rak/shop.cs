using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Transform cube;

    public int cost;
    public Action effect;

    public Text costText;
    public Button purchaseButton;

    private void Start()
    {
    }

    public void PurchaseSlime()
    {
        if (GameManager.instance.money >= cost)
        {
            GameManager.instance.money -= cost;
            print("슬라임 색깔 변경완료");
            //구매 버튼을 눌렀을 시 슬라임 색 변경 코드
        }
        if (GameManager.instance.money < cost)
        {
            print("돈이 부족합니다");
        }
    }

    public void PurchaseRope()
    {
        if (GameManager.instance.money >= cost)
        {
            GameManager.instance.money -= cost;
            print("로프 색깔 변경완료");
            //구매 버튼을 눌렀을 시 로프 색 변경 코드
        }
        if (GameManager.instance.money < cost)
        {
            print("돈이 부족합니다");
        }
    }

    // 게임 종료시에 호출되도록 수정바람
    void SaveStuff()
    {
        PlayerPrefs.SetInt("Money", GameManager.instance.money);
        PlayerPrefs.SetFloat("CubePosX", cube.position.x);
        PlayerPrefs.SetFloat("CubePosY", cube.position.y);
        PlayerPrefs.SetFloat("CubePosZ", cube.position.z);
    }

    void LoadStuff()
    {
        //GameManager.instance.money = PlayerPrefs.GetInt("Money");
        cube.position = new Vector3(PlayerPrefs.GetFloat("CubePosX"), PlayerPrefs.GetFloat("CubePosY"), PlayerPrefs.GetFloat("CubePosZ"));
    }

    void DeleteSaveData()
    {
        PlayerPrefs.DeleteAll();
    }
}