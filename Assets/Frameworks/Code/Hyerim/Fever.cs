using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using System;

public class Fever : MonoBehaviour
{
    public Transform feverSpawnContainer;
    public List<Transform> feverSpawnPosition = new List<Transform>();
    public List<GameObject> feverPrefab = new List<GameObject>();
    public List<GameObject> feverObject = new List<GameObject>();
    public List<Image> feverUIsprite = new List<Image>();
    public bool[] hasFever;
    public GameObject Coin;
    public Text[] FeverText = new Text[6];
    public List<Text> FeverShow2 = new List<Text>();
    /*public List<GameObject> CoinObject = new List<GameObject>();
    public List<Transform> CoinDropPosition = new List<Transform>();
    public List<Image> CoinImage = new List<Image>;*/
    public int CoinNumber = 0;

    public static Action<Collider2D> OnHitFever;

    private void Awake()
    {
        hasFever = new bool[feverUIsprite.Count];
        CreateFever();
        OnHitFever += FeverCheck;
    }
    private void CreateFever()
    {
        IListExtensions.Shuffle(feverSpawnPosition);
        for (int i = 0; i < feverPrefab.Count; i++)
        {
            var feverObject = Instantiate(feverPrefab[i], feverSpawnPosition[i].position, Quaternion.identity, feverSpawnContainer);
            this.feverObject.Add(feverObject);
        }
    }

    // 플레이어가 피버 충돌시 호출할 생각

    Transform CoinContainer;
    public void FeverCheck(Collider2D col)
    {
        var feverList = feverObject;
        int totalCount = 0;
        for (int i = 0; i < feverList.Count; i++)
        {
            if (col.gameObject.Equals(feverList[i]))
            {
                hasFever[i] = true;
                totalCount++;
                ChangeAlpha(feverUIsprite[i]);
            }
        }
        if (totalCount == hasFever.Length)
        {
            for(int i=0; i<FeverText.Length; i++)
            {
                /*FeverText[i].SetActive(false);*//*왜 안되는지 모르겠습니다*/
            }
            for (int i = 0; i < CoinNumber; i++)
            {
                Coin.transform.position = Camera.main.transform.position + UnityEngine.Random.Range(-3, 3) * Vector3.right;
                Instantiate(Coin, Coin.transform.position, Quaternion.identity,null);
                Destroy(Coin, 10);
            }

        }
    }

    public void ChangeAlpha(Image fever)
    {
        fever.color = new Color(1, 1, 1);
    }

}