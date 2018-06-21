using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text currentCoinText;
    public Text errorText;
    public int cost;

    [Header("Model")]
    private GameObject playerModel;
    private GameObject hook;
    private LineRenderer line;

    private void Start()
    {
        ShowModel();
    }
    private void ShowCurCoin()
    {
        currentCoinText.text = GameManager.instance.money.ToString();
    }

    private void ShowModel()
    {
        if (hook != null)
        {
            hook.GetComponent<RopeScript>().enabled = false;
            Destroy(hook);
        }
        if (playerModel != null)
        {
            Destroy(playerModel);
        }

        playerModel = Instantiate(GameManager.instance.playerPrefab, new Vector3(3.5f, 0, 0), Quaternion.identity, null);
        playerModel.GetComponent<PlayerControl>().enabled = false;
        playerModel.GetComponent<Throwhook>().enabled = false;
        playerModel.transform.localScale = new Vector3(8, 8, 1);
        hook = Instantiate(playerModel.GetComponent<Throwhook>().hook, new Vector3(3.5f, 2.6f, 0), Quaternion.identity, null);
        hook.GetComponent<RopeScript>().player = playerModel;
        Invoke("SetRopePlayer", 0.3f);
        ShowCurCoin();
    }
    private void SetRopePlayer()
    {
        hook.GetComponent<RopeScript>().player = playerModel;
    }
    private void ShowRope()
    {
        line = hook.GetComponent<LineRenderer>();
        if (line != null)
        {
            line.startColor = GameManager.instance.lineStartColor;
            line.endColor = GameManager.instance.lineEndColor;
            ShowCurCoin();
        }
    }

    public void PurchaseSlime()
    {
        if (GameManager.instance.money >= cost)
        {
            GameManager.instance.money -= cost;
            print("슬라임 색깔 변경완료");
            GameManager.instance.ChangePlayerSkin();
            //구매 버튼을 눌렀을 시 슬라임 색 변경 코드
            ShowModel();
        }
        else
        {
            StartCoroutine(ShowErrorText());
        }
    }

    public void PurchaseRope()
    {
        if (GameManager.instance.money >= cost)
        {
            GameManager.instance.money -= cost;
            print("로프 색깔 변경완료");
            GameManager.instance.ChangeRopeSkin();
            ShowRope();
            //구매 버튼을 눌렀을 시 로프 색 변경 코드
        }
        else
        {
            StartCoroutine(ShowErrorText());
        }
    }

    private IEnumerator ShowErrorText()
    {
        errorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        errorText.gameObject.SetActive(false);
    }

    // 게임 종료시에 호출되도록 수정바람
    void SaveStuff()
    {
        PlayerPrefs.SetInt("Money", GameManager.instance.money);
    }
    void DeleteSaveData()
    {
        PlayerPrefs.DeleteAll();
    }
}